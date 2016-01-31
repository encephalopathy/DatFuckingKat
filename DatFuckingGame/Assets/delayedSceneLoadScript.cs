using UnityEngine;
using System.Collections;

public class delayedSceneLoadScript : MonoBehaviour {

	public GameObject fadeInObject;

	void Start() {
        StartCoroutine(LoadLevel());
        fadeInObject.GetComponent<fadeInLight>().setSceneStart();
    }
    
    IEnumerator LoadLevel() {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(1);
    }
}
