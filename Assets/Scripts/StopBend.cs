﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StopBend : MonoBehaviour
{
    public AudioSource music;
    public AudioSource binaural;
    public Controller startBend;
    public Renderer pauseRenderer;
    public AudioSource pauseButtonSound;


    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);

        if (collider.gameObject.name == "LeftHandCollider")
        {

            startBend.enabled = true;
            startBend.PauseEffect();
            Debug.Log("Pausing bend");
            pauseButtonSound.Play();

            music.Stop();
            binaural.Play();

            pauseRenderer.enabled = false;

        }

    }
}

    