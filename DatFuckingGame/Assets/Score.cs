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
            PhraseValidator phraseValid = phraseValidator.GetComponent<PhraseValidator>();
            SentanceStaticSaver.TotalMatches = phraseValid.numberOfMatches;
            GetComponent<Text>().text = string.Format("Number of Matches: {0}", phraseValid.numberOfMatches);
        }
	}
}
