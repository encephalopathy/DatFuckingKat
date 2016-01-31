using UnityEngine;
using System.Collections;
using System;

public class PhraseValidator : MonoBehaviour {


	public string finalIncantation = "";

    public string[][] phraseMatchPossibilities;

    public event EventHandler<EventArgs>PhraseMatch;

    public float phraseMatchEventDelay = 2f;

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
        slots[3] = slotA;
        slots[2] = slotB;
        slots[1] = slotC;
        slots[0] = slotD;
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
            Debug.Log("MATCH FOUND!!!!");
            StartCoroutine(VerifyPhraseAction(phraseMatchEventDelay));
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

        if (slots[0].transform.GetComponentInChildren<wordValuesDto>() != null &&
        slots[1].transform.GetComponentInChildren<wordValuesDto>() != null &&
        slots[2].transform.GetComponentInChildren<wordValuesDto>() != null &&
        slots[3].transform.GetComponentInChildren<wordValuesDto>() != null)
        {
            if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
             slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" &&
             slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" &&
             slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where")
            {
                valid = true;
                addPhrase();
            }
            else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" &&
             slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
             slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" &&
             slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where")
            {
                valid = true;
                addPhrase();
            }
            else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
             slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" &&
             slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where" &&
             slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when")
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
