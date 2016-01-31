using UnityEngine;
using System.Collections;

public class TurnToMousePos : MonoBehaviour {

    public Camera mouseCam;
    public float zDistance = 1;
    public float yOffset = -2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mScreenPos = Input.mousePosition;
        mScreenPos.z = zDistance;
        Vector3 mWorldPos = mouseCam.ScreenToWorldPoint(mScreenPos);// + new Vector3(0, yOffset, 0);

        //mWorldPos.y = mWorldPos.y + yOffset;
        transform.LookAt(mWorldPos, Vector3.up);
        transform.Rotate(new Vector3(1.0f, 0, 0), 90);
        transform.Rotate(new Vector3(0, 1, 0), 180);
        ////transform.LookAt(mWorldPos, Vector3.left);
        //Vector3 direction = mWorldPos - transform.position;
        //Quaternion toRot = Quaternion.FromToRotation(transform.up, direction);
        //transform.localRotation = toRot;// Quaternion.Lerp(transform.localRotation, toRot, 100*Time.time);
    }
}
