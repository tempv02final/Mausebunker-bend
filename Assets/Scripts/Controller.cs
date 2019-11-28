using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Transform origin;
    public float     minDistance = 10f;
    public float     maxDistance = 200f;
    public bool      stretchInY  = false;


    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalMatrix("_WorldToOrigin"  , origin.worldToLocalMatrix);
        Shader.SetGlobalMatrix("_OriginToWorld"  , origin.localToWorldMatrix);
        Shader.SetGlobalFloat ("beginingDistance", minDistance);
        Shader.SetGlobalFloat ("maxDistance"     , maxDistance);
        Shader.SetGlobalFloat ("stretchInY"      , stretchInY? 1: 0);
    }
}
