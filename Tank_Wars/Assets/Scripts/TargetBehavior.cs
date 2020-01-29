using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public static int remaining = 3;

    private Renderer rend;
    private AudioSource mAudio;

    

    // Start is called before the first frame update
    void Start()
    {
        mAudio = GetComponent<AudioSource>();
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            // disable mesh renderer
            //rend = gameObject.GetComponent<MeshRenderer>();
            rend.enabled = false;

            // loop through colliders to disable them
            foreach(Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }

            mAudio.Play(); // play audio from source

            --remaining;
            Destroy(gameObject, 1f); // destroy game object with a 1 second timer to allow audio source to play
        }
    }
}
