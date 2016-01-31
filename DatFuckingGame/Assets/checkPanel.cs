using UnityEngine;
using System.Collections;

public class checkPanel : MonoBehaviour {

	public GameObject panel;
	public PhraseValidator phraseValidator;

	public void Start() {
		phraseValidator = panel.GetComponent<PhraseValidator>();

	}
   
	public void isValidPhrase() {
		if(phraseValidator.isValid()) {
			Debug.Log("valid!");
		}
		else {
			Debug.Log("failed!");
		}

	}

}
