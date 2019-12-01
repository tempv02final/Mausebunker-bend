using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBend : MonoBehaviour
{
    public AudioSource music;
    public AudioSource binaural;
    public Renderer playRenderer;
    public Controller startBend;

    private bool BUUMactive = false;
  

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
    
        if (collider.gameObject.name == "LeftHandCollider")
        {
            
           // OnTriggerEnter.SetActive(true);
            BUUMactive = true;
            music.Play();
            startBend.enabled = true;
            startBend.StartEffect();
            Debug.Log("starting bend");

            playRenderer.enabled = false;
            Debug.Log("BUUMactive is true");

        }
   
    }

    
    // Start is called before the first frame update
    void Start()
    {
        binaural.Play();
    }

    void Update()
    {
        if (BUUMactive == true)
        {
            binaural.Stop();
        }
    }
    
}
