using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WordBankProvider : MonoBehaviour {

    private WordBank wordBank = new WordBank();

	// Use this for initialization
	void Start () {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Word");
        int index = Random.Range(0, wordBank.words.Count);
        foreach (GameObject obj in slots)
        {
            KeyValuePair<string, string> field = wordBank.words[index];
            if (field.Key == "Food" && field.Value == "Red")
            {
                //(obj as Text).text = field.Key;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
