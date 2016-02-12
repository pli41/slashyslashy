using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void StartDestroy()
    {
        anim.SetTrigger("Destroy");
        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("SelfDestroy", animationLength);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
        
    }

}
