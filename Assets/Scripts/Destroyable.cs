using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

    public Animator anim;
    public Collider2D col;
    public bool active;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartDestroy()
    {

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

}
