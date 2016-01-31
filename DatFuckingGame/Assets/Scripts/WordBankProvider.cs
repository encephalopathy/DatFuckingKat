using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class WordBankProvider : MonoBehaviour {

    private WordBank wordBank;

    private GameObject[] slots;

    public GameObject textObject;

	// Use this for initialization
	public void Start () {
        wordBank = new WordBank();
        this.slots = GameObject.FindGameObjectsWithTag("WordBank");
        RefillEmptyWords();
	}

    public void RefillEmptyWords()
    {
        //Debug.Log("Word count: ")
        //DebugDic(wordBank.words);
        
        foreach (GameObject slot in slots)
        {
            
            if (slot.GetComponentInChildren<Text>() == null)
            {
                //TODO: Do something smarter than this.
                int index = Random.Range(0, 4);
                KeyValuePair<string, string> word = wordBank[index];
                GameObject text = Instantiate(textObject, Vector3.zero, Quaternion.identity) as GameObject;
                wordValuesDto dto = text.GetComponent<wordValuesDto>();
                dto.wordText = word.Key;
                dto.wordType = word.Value;
                text.GetComponent<Text>().text = word.Key;
                text.transform.SetParent(slot.transform);
            }
        }
    }

    private void DebugDic(IDictionary<int, KeyValuePair<string, string>> data)
    {
        foreach (KeyValuePair<int, KeyValuePair<string, string>> element in data)
        {
            Debug.Log("Key: " + element.Key + "Value: " + element.Value.Key + " Type: " + element.Value.Value);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
