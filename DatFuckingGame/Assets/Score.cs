using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject phraseValidator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (phraseValidator != null)
        {
            GetComponent<Text>().text = string.Format("Number of Maches: {0}", phraseValidator.GetComponent<PhraseValidator>().numberOfMatches);
        }
	}
}
