using UnityEngine;
using System.Collections;

public class CrecentAttack : Projectile {


	// Use this for initialization
	void Start () {
        rigid.velocity = new Vector2(horiSpeed, 0f) ;
        Invoke("DestroySelf", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("222");
        if (col.GetComponent<Destroyable>())
        {
            col.GetComponent<Destroyable>().StartDestroy();
            //Debug.Log("Destroy box");
        }

    }


}
