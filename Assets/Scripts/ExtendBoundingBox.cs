using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBoundingBox : MonoBehaviour {

	// Use this for initialization
	void Start () {

        MeshFilter[] rs = this.transform.GetComponentsInChildren<MeshFilter>();

        Bounds b = new Bounds(Vector3.zero, new Vector3(100000f, 100000f, 10000f));

        foreach(MeshFilter r in rs)
        {
            r.mesh.bounds = b;
        }

	}
}
