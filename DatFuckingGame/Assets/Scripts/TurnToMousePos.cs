using UnityEngine;
using System.Collections;

public class TurnToMousePos : MonoBehaviour {

    public Camera mouseCam;
    public float zDistance = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mScreenPos = Input.mousePosition;
        mScreenPos.z = zDistance;
        Vector3 mWorldPos = mouseCam.ScreenToWorldPoint(mScreenPos);
        //transform.LookAt(mWorldPos, Vector3.left);
        Vector3 direction = mWorldPos - transform.position;
        Quaternion toRot = Quaternion.FromToRotation(transform.up, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRot, 5*Time.time);
	}
}
