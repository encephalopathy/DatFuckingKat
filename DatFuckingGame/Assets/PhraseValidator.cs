using UnityEngine;
using System.Collections;

public class PhraseValidator : MonoBehaviour {


	public string finalIncantation = "";

	public GameObject slotA,slotB,slotC,slotD;
	public GameObject[] slots;
	
	public void Start () {
		slots = new GameObject[4];
		slots = getSlots();
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

        wordValuesDto slotOne = slots[0].transform.GetComponentInChildren<wordValuesDto>();
        wordValuesDto slotTwo = slots[1].transform.GetComponentInChildren<wordValuesDto>();

        if (slotOne != null &&
		slotTwo != null &&
		slots[2].transform.GetComponentInChildren<wordValuesDto>() != null &&
		slots[3].transform.GetComponentInChildren<wordValuesDto>() != null ) {
			if(slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where"  ) {
				valid = true;
				addPhrase();
			}
			else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where"  ) {
			 	valid = true;
			 	addPhrase();
			}
			else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when"  ) {
				valid = true;
				addPhrase();
			}
	}

	Debug.Log(finalIncantation);
		return valid;
	}

	public void addPhrase() {
		finalIncantation += slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
		finalIncantation += slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
		finalIncantation += slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + " ";
		finalIncantation += slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordText + ".";
	}


}
