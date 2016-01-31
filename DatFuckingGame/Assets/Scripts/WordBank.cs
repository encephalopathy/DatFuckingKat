using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordBank : MonoBehaviour {

    IDictionary<string, string> words = new Dictionary<string, string>();

    public IList<string> what = new List<string>();
    public IList<string> where = new List<string>();
    public IList<string> when = new List<string>();
    public IList<string> who = new List<string>();

	void Start () {

	}

    private void CreateWhatWords()
    {
        //Put a word + phrase type in the dictionary using words.Add(string, string), and to the list for what.Add(string)
    }

    private void CreateWhenWords()
    {

    }

    private void CreateWhereWords()
    {

    }

    private void CreateWhyWords()
    {

    }
	
}
