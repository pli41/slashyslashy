using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public PlayerController pc;
    public Collider2D col;
    public int damage;

	// Use this for initialization
	void Start () {
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        col.enabled = pc.state == PlayerController.PlayerState.Attack;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (pc.state == PlayerController.PlayerState.Attack)
        {
            if (col.tag == "Obstacle")
            {
                col.GetComponent<Destroyable>().StartDestroy();
                //Debug.Break();
                //Debug.Log("Destroy box by weapon");
                //active = false;
            }
            else if (col.tag == "Enemy")
            {
                col.gameObject.SendMessage("ReceiveDamage", damage);
                //Debug.Break();
                //active = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (pc.state == PlayerController.PlayerState.Attack)
        {
            if (col.tag == "Obstacle")
            {
                col.GetComponent<Destroyable>().StartDestroy();
                //Debug.Break();
                //Debug.Log("Destroy box by weapon");
                //active = false;
            }
            else if (col.tag == "Enemy")
            {
                col.gameObject.SendMessage("ReceiveDamage", damage);
                //Debug.Break();
                //active = false;
            }
        }
    }
}
