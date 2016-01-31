using UnityEngine;
using System.Collections;
using System;

public class PhraseValidator : MonoBehaviour {


	public string finalIncantation = "";

    public string[][] phraseMatchPossibilities;

    public event EventHandler<EventArgs>PhraseMatch;

    //Used to match 
    public string[] phraseMatch = null;

	public GameObject slotA,slotB,slotC,slotD;
	public GameObject[] slots;
    public WordBankProvider wordBankProvider;

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
	}

	public GameObject[] getSlots () {
		slots[0] = slotA;
		slots[1] = slotB;
		slots[2] = slotC;
		slots[3] = slotD;
		Debug.Log(slots[0]);
		Debug.Log(slots[1]);
		Debug.Log(slots[2]);
		Debug.Log(slots[3]);

		return slots;

	}

    private void ChangePhrase()
    {
        phraseMatch = phraseMatchPossibilities[UnityEngine.Random.Range(0, phraseMatchPossibilities.Length)];
    }

    public void Update()
    {
        bool isCurrentPhraseValid = isValid();
        if (isCurrentPhraseValid && !wasLastPhraseValid)
        {
            StartCoroutine(VerifyPhraseAction(2.0f));
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
    public IEnumerator VerifyPhraseAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangePhrase();
        Refresh();
        PhraseMatch(this, new EventArgs());
        if (wordBankProvider != null)
        {
            wordBankProvider.RefillEmptyWords();
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
		slotFour != null ) {
			if(slotOne.wordType == phraseOne &&
			 slotTwo.wordType == phraseTwo && 
			 slotThree.wordType == phraseThree && 
			 slotFour.wordType == phraseFour  ) {
				valid = true;
				addPhrase();
			}
			else if (slotOne.wordType == phraseOne &&
			 slotTwo.wordType == phraseTwo && 
			 slotThree.wordType == phraseThree && 
			 slotFour.wordType == phraseFour  ) {
			 	valid = true;
			 	addPhrase();
			}
			else if (slotOne.wordType == phraseOne &&
			 slotTwo.wordType == phraseTwo && 
			 slotThree.wordType == phraseThree && 
			 slotFour.wordType == phraseFour  ) {
				valid = true;
				addPhrase();
			}
	    }

		return valid;
	}

	public void addPhrase() {
        wordValuesDto slotOne = slots[0].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotTwo = slots[1].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotThree = slots[2].GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotFour = slots[3].GetComponentInChildren<wordValuesDto>();

        finalIncantation += slotOne.wordText + " ";
		finalIncantation += slotTwo.wordText + " ";
		finalIncantation += slotThree.wordText + " ";
		finalIncantation += slotFour.wordText + ".\n";
	}


}
