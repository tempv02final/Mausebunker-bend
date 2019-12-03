using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public  Transform        origin;
    public  float            minDistance   = 10f;
    public  float            maxDistance   = 200f;
    public  bool             stretchInY    = false;
    public  AnimationCurve   bendControlelr;
    public  float            animationSpeed = 0.1f;
    private bool             isBending     = false;
    private float            effectTimer   = 0f;
    private float            unitTime      = 0f;

    // Update is called once per frame
    void Update()
    {
        effectTimer += Time.deltaTime* animationSpeed * (isBending ? 1f : 0f);
        print(effectTimer);
        unitTime     = bendControlelr.Evaluate(effectTimer);
        Shader.SetGlobalMatrix("_WorldToOrigin"  , origin.worldToLocalMatrix);
        Shader.SetGlobalMatrix("_OriginToWorld"  , origin.localToWorldMatrix);
        Shader.SetGlobalFloat ("beginingDistance", minDistance);
        Shader.SetGlobalFloat ("maxDistance"     , maxDistance);
        Shader.SetGlobalFloat ("stretchInY"      , stretchInY? 1: 0);
        Shader.SetGlobalFloat ("iTime"           , unitTime);
    }

    public bool IsPlaying()
    {
        return isBending;
    }

    public void StartEffect()
    {

        isBending = true;
    }

    public void PauseEffect()
    {
        isBending = false;
    }

    public void RestartEffect()
    {
        effectTimer = 0;
    }
}
