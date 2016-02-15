using UnityEngine;
using System.Collections;

public class EnemyProjectile : EnemyAttack {

    public Rigidbody2D rigid;

    public bool active;
    public int damage;
    public float horiSpeed;
    public float gravityScale;
    public float persistTime;

    // Use this for initialization
    void Start () {
        rigid.velocity = new Vector2(-horiSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

	public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
