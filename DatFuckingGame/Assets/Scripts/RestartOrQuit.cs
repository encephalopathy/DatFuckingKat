using UnityEngine;
using System.Collections;

public class RestartOrQuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void Restart()
    {
        //Something to reset all static variables
        SentanceStaticSaver.Clear();
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
