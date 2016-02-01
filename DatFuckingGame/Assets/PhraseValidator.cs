using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PhraseValidator : MonoBehaviour {


	public string finalIncantation = "";

    public string[][] phraseMatchPossibilities;

    public event EventHandler<EventArgs>PhraseMatch;

    //Used to match 
    public string[] phraseMatch = null;

	public GameObject slotA,slotB,slotC,slotD;
    public Color whoColor, whatColor, whereColor, whenColor;
    public Text textA, textB, textC, textD;
	public GameObject[] slots;
    public WordBankProvider wordBankProvider;
    public AudioSource[] audioSouces;

    public int numberOfMatches = 0;

    //Used so isValid function does not get called more than once.
    bool wasLastPhraseValid = false;

    public float delay = 2;

	public void Start () {
		slots = new GameObject[4];
		slots = getSlots();
        phraseMatchPossibilities = new string[3][];
        phraseMatchPossibilities[0] = new string[4] { "who", "what", "where", "when" };
        phraseMatchPossibilities[1] = new string[4] { "who", "what", "when", "where" };
        phraseMatchPossibilities[2] = new string[4] { "when", "who", "what", "where" };

        ChangePhrase();

        audioSouces = GetComponents<AudioSource>();
    }

	public GameObject[] getSlots () {
        slots[0] = slotA;
        slots[1] = slotB;
        slots[2] = slotC;
        slots[3] = slotD;
        //Debug.Log(slots[0]);
		//Debug.Log(slots[1]);
		//Debug.Log(slots[2]);
		//Debug.Log(slots[3]);

		return slots;

	}

    private void ChangePhrase()
    {
        phraseMatch = phraseMatchPossibilities[UnityEngine.Random.Range(0, phraseMatchPossibilities.Length)];
        slotA.GetComponent<Image>().color = GetPhraseColor(phraseMatch[0]);
        textA.text = phraseMatch[0];
        ///textA.color = GetPhraseColor(phraseMatch[0]);
        slotB.GetComponent<Image>().color = GetPhraseColor(phraseMatch[1]);
        textB.text = phraseMatch[1];
        slotC.GetComponent<Image>().color = GetPhraseColor(phraseMatch[2]);
        textC.text = phraseMatch[2];
        slotD.GetComponent<Image>().color = GetPhraseColor(phraseMatch[3]);
        textD.text = phraseMatch[3];
    }

    private Color GetPhraseColor(string phrase)
    {
        Color ret = Color.white;
        switch (phrase)
        {
            case ("who"): {
                    ret = whoColor;
                    break;
                }
            case ("what"): {
                    ret = whatColor;
                    break;
                }
            case ("where"): {
                    ret = whereColor;
                    break;
                }
            case ("when"):
                {
                    ret = whenColor;
                    break;
                }
        }
        return ret;
    }

    public void Update()
    {
        bool isCurrentPhraseValid = isValid();
        
        if (isCurrentPhraseValid && !wasLastPhraseValid)
        {
            Debug.Log("MATCH FOUND!!!!");
            VerifyPhraseAction();
            numberOfMatches++;
        }
        else if (AreAllSlotsFilled() && !isCurrentPhraseValid)
        {
            if (!audioSouces[0].isPlaying)
            {
                audioSouces[0].Play();
                foreach (GameObject slot in slots)
                {
                    slot.GetComponentInChildren<DragHandler>().SetToOriginalParent();
                }
            }
        }

        wasLastPhraseValid = isCurrentPhraseValid;
    }

    /// <summary>
    /// Performs a small delay of 2 seconds before the phrase changes, the words get deleted for the phrase,
    /// and the phrase match events occurs.  This is also the time when the empty words in the word bank get
    /// replaced with an actual word.
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    public void VerifyPhraseAction()
    {
        ChangePhrase();
        Refresh();

        //PhraseMatch(this, new EventArgs());
        if (wordBankProvider != null)
        {
            wordBankProvider.RefillEmptyWords();
            audioSouces[1].Play();
        }
    }

    /// <summary>
    /// Destroys all words in the AvailableWordsPanel
    /// </summary>
    public void Refresh()
    {
        DestroyChildren(slotA.transform);
        DestroyChildren(slotB.transform);
        DestroyChildren(slotC.transform);
        DestroyChildren(slotD.transform);
    }

    private void DestroyChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

	public bool isValid() {
		if (isValidPhrase(slots))
    	{
        	return true;
    	}
    	return false;
	}

    private bool AreAllSlotsFilled()
    {
        wordValuesDto slotOne = slots[0].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotTwo = slots[1].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotThree = slots[2].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotFour = slots[3].GetComponentInChildren<wordValuesDto>();

        return slotOne != null &&
        slotTwo != null &&
        slotThree != null &&
        slotFour != null;
    }

// I know...I KNOW OK? It's a game jam...and I don't care...STOP JUDGING ME!
	public bool isValidPhrase(GameObject[] slots) {
		bool valid = false;

        wordValuesDto slotOne = slots[0].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotTwo = slots[1].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotThree = slots[2].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotFour = slots[3].GetComponentInChildren<wordValuesDto>();
        string phraseOne = phraseMatch[0];
        string phraseTwo = phraseMatch[1];
        string phraseThree = phraseMatch[2];
        string phraseFour = phraseMatch[3];

        if (slotOne != null &&
        slotTwo != null &&
        slotThree != null &&
        slotFour != null)
        {
            if (slotOne.wordType == phraseOne &&
             slotTwo.wordType == phraseTwo &&
             slotThree.wordType == phraseThree &&
             slotFour.wordType == phraseFour)
            {
                valid = true;
                addPhrase();
            }
            else if (slotOne.wordType == phraseOne &&
             slotTwo.wordType == phraseTwo &&
             slotThree.wordType == phraseThree &&
             slotFour.wordType == phraseFour)
            {
                valid = true;
                addPhrase();
            }
            else if (slotOne.wordType == phraseOne &&
             slotTwo.wordType == phraseTwo &&
             slotThree.wordType == phraseThree &&
             slotFour.wordType == phraseFour)
            {
                valid = true;
                addPhrase();
            }
        }

        return valid;
	}

	public void addPhrase() {
        finalIncantation += slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
        finalIncantation += slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
        finalIncantation += slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
        finalIncantation += slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + ".";
	}


}
