using UnityEngine;
using System.Collections;

public class RestartOrQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        //Something to reset all static variables
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
