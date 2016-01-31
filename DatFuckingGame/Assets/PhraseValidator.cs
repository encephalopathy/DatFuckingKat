using UnityEngine;
using System.Collections;

public class PhraseValidator : MonoBehaviour {

	public GameObject[] slots;
	
	public void Start () {
		slots = getSlots();

	}

	public GameObject[] getSlots () {
		//google for all
		GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
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
		if(slots[0].transform.GetComponentInChildren<wordValuesDto>() != null &&
		slots[1].transform.GetComponentInChildren<wordValuesDto>() != null &&
		slots[2].transform.GetComponentInChildren<wordValuesDto>() != null &&
		slots[3].transform.GetComponentInChildren<wordValuesDto>() != null ) {
			if(slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where"  ) {
				valid = true;
			}
			else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where"  ) {
			 	valid = true;

			}
			else if (slots[3].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "who" &&
			 slots[2].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "what" && 
			 slots[1].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "where" && 
			 slots[0].transform.GetChild(0).GetComponent<wordValuesDto>().wordType == "when"  ) {
				valid = true;
			}
	}
		return valid;
	}

}
