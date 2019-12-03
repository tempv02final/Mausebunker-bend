using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour {


    public  Controller  refController;
    public  AudioSource binural;
    public  AudioSource BUUM;
    public  AudioSource playButton;
    public  AudioSource pauseButton;

    private Renderer    r_Play;
    private Renderer    r_Pause;
    

    // Use this for initialization
    void Start () {
        

        Renderer [] rs      = this.transform.GetComponentsInChildren<Renderer>();
                    r_Play  = rs[0];
                    r_Pause = rs[1];

        r_Play.enabled  = !refController.IsPlaying();
        r_Pause.enabled =  refController.IsPlaying();

    }

    private void play()
    {
        refController.StartEffect();
        playButton   .Play();
        binural      .Pause();
        BUUM         .Play();

    }
    private void pause()
    {
        refController.PauseEffect();
        pauseButton  .Play();
        binural      .Play();
        BUUM         .Pause();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "LeftHandCollider" || collider.gameObject.name == "RightHandCollider")
        {

            if (refController.IsPlaying()) pause();
            else play();

            r_Play.enabled  = !refController.IsPlaying();
            r_Pause.enabled =  refController.IsPlaying();
        }
    }
}
