using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

    public Animator anim;
    public Collider2D col;
    public bool active;

    public string material;

    public AudioClip woodCrack;

    AudioSource aus;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartDestroy()
    {
        if (material.Equals("Wood"))
        {
            PlayAudio(woodCrack);
        }
        active = false;
        anim.SetTrigger("Destroy");
        col.enabled = false;
        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("SelfDestroy", animationLength);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
        
    }

    void PlayAudio(AudioClip clip)
    {
        aus.Stop();
        aus.PlayOneShot(clip);
    }
}
