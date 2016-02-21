using UnityEngine;
using System.Collections;

public class CrecentAttack : Projectile {


	// Use this for initialization
	void Start () {
        active = true;
        rigid.velocity = new Vector2(horiSpeed, 0f);
        Invoke("DestroySelf", persistTime);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("222");
        if (active)
        {
            if (col.GetComponent<Destroyable>())
            {
                col.GetComponent<Destroyable>().StartDestroy();
                //Debug.Log("Destroy box");
                //active = false;
            }
            else if (col.tag == "Enemy")
            {
                col.gameObject.SendMessage("ReceiveDamage", damage);
                //Debug.Log(col.gameObject);
                //active = false;
            }
        }

        

    }


}
