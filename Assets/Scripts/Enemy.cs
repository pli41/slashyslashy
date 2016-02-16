using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int hp;
    public bool active;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReceiveDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            DestroySelf();
        }
    }

    public virtual void Attack()
    {

    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }


}
