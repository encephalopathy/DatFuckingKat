using UnityEngine;
using System.Collections;

public class destroySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void destroyMe() {

		Destroy(this.gameObject);
	}
}
