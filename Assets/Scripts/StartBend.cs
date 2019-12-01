using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBend : MonoBehaviour
{
    public AudioSource music;
    public AudioSource binaural;
    public AudioSource playButtonSound;
    public Renderer playRenderer;
    public Renderer pauseRenderer;
    public Controller startBend;

    private bool BUUMactive = false;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
    
        if (collider.gameObject.name == "LeftHandCollider")
        {

            BUUMactive = true;
            playButtonSound.Play();    //add delay before play music
           // music.Play();
            startBend.enabled = true;
            startBend.StartEffect();
            Debug.Log("starting bend");

            playRenderer.enabled = false;
            pauseRenderer.enabled = true;

        }
   
    }

    
    // Start is called before the first frame update
    void Start()
    {
        binaural.Play();
        pauseRenderer.enabled = false;

    }

    void Update()
    {
        if (BUUMactive == true)
        {
            binaural.Stop();
        }
    }
    
}
