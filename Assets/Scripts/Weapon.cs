using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public PlayerController pc;
    public Collider2D col;
    public int damage;
    public WeaponController wc;

	// Use this for initialization
	void Start () {
        wc = transform.parent.GetComponent<WeaponController>();
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.tag == "Obstacle")
            {
                col.GetComponent<Destroyable>().StartDestroy();
                this.col.enabled = false;
                //Debug.Break();
                Debug.Log("Destroy box by weapon");
                //active = false;
            }
            else if (col.tag == "Enemy")
            {
                col.gameObject.SendMessage("ReceiveDamage", damage);
                this.col.enabled = false;
                //Debug.Break();
                //active = false;
            }
            
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
            if (col.tag == "Obstacle")
            {
                col.GetComponent<Destroyable>().StartDestroy();
                this.col.enabled = false;
                //Debug.Break();
                //Debug.Log("Destroy box by weapon");
                //active = false;
            }
            else if (col.tag == "Enemy")
            {
                col.gameObject.SendMessage("ReceiveDamage", damage);
                this.col.enabled = false;
                //Debug.Break();
                //active = false;
            }
        
    }
}
