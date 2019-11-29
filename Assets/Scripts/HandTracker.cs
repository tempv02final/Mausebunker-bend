using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandTracker : MonoBehaviour {

    public  GameObject RightHandRef;
    public  GameObject LeftHandRef;

    private GameObject rightHandCollider;
    private GameObject leftHandCollider;

	// Use this for initialization
	void Start () {
        rightHandCollider = this.transform.GetChild(0).gameObject;
        leftHandCollider  = this.transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        rightHandCollider.transform.position = RightHandRef.transform.position;
        leftHandCollider.transform.position  = LeftHandRef.transform.position;

	}
}
