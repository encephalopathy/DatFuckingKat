﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class WordBankProvider : MonoBehaviour {

    private WordBank wordBank;

    private GameObject[] slots;

    public GameObject textObject;

    public GameObject slotPanel;

	// Use this for initialization
	public void Start () {
        wordBank = new WordBank();
        this.slots = GameObject.FindGameObjectsWithTag("WordBank");
        RefillEmptyWords();
	}

    public void RefillEmptyWords()
    {
        int numberOfSlots = slots.Length;
        List<Text> textStringToShuffle = new List<Text>();
        //Debug.Log("Word count: ")
        //DebugDic(wordBank.words);
        
        for (int i = 0; i <  numberOfSlots; ++i)
        {
            GameObject slot = slots[i];
            PhraseValidator phraseValidatorRef = slotPanel.GetComponent<PhraseValidator>();
            GameObject text = null;
            if (i < phraseValidatorRef.phraseMatch.Length)
            {
                string word = wordBank.GetWord(phraseValidatorRef.phraseMatch[i]);
                text = Instantiate(textObject, Vector3.zero, Quaternion.identity) as GameObject;
                wordValuesDto dto = text.GetComponent<wordValuesDto>();
                Debug.Log("Word Text: " + word);
                Debug.Log("Word Type: " + phraseValidatorRef.phraseMatch[i]);
                dto.wordText = word;
                dto.wordType = phraseValidatorRef.phraseMatch[i];
                text.GetComponent<Text>().text = word;
                text.transform.SetParent(slot.transform);
            }
            else if (slot.GetComponentInChildren<Text>() == null)
            {
                //TODO: Do something smarter than this.
                int index = Random.Range(0, 4);
                KeyValuePair<string, string> word = wordBank[index];
                text = Instantiate(textObject, Vector3.zero, Quaternion.identity) as GameObject;
                wordValuesDto dto = text.GetComponent<wordValuesDto>();
                dto.wordText = word.Key;
                dto.wordType = word.Value;
                text.GetComponent<Text>().text = word.Key;
                text.transform.SetParent(slot.transform);
            }
            textStringToShuffle.Add(text.GetComponent<Text>());
        }

        //Shuffle all the aviable word bank options so it is a bit more interesting.
        Shuffle(textStringToShuffle);
    }

    /// <summary>
    /// Fisher Yates Shuffle over an array, ensures uniform randomness.
    /// </summary>
    /// <param name="array"></param>
    private void Shuffle(List<Text> array)
    {
        int n = array.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(new System.Random().NextDouble() * (n - i));
            string t = array[r].text;
            array[r].text = array[i].text;
            array[i].text = t;
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
