using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = transform.Find("Flag").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("Rise");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, col.transform.parent.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
