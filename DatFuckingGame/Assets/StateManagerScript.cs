using UnityEngine;
using System.Collections;

public class StateManagerScript : MonoBehaviour {


	static int  START = 0;
	static int  GAME = 1;
	static int  END = 2;

	public int state = START;

	// Use this for initialization
	void Start () {
		state = START;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
