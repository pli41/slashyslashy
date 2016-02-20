using UnityEngine;
using System.Collections;

public class GhostBall : EnemyProjectile {

    public Animator animator;

	// Use this for initialization
	void Start () {
        active = true;
        Invoke("DestroySelf", persistTime);
        rigid.velocity = new Vector2(horiSpeed, 0f);
        rigid.gravityScale = gravityScale;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && col.name == "FrontCheck" && active)
        {
            col.transform.parent.gameObject.GetComponent<PlayerController>().SendMessage("HandleDamage", damage);
        }


        if (col.tag == "Ground" || col.tag == "Obstacle")
        {
            Debug.Log("collide with " + col.gameObject);
            DestroySelf();
        }
    }

	public override void DestroySelf(){
		active = false;
		animator.SetTrigger("Destroy");
        Invoke("DestroyObject", 1f);
	}

    public void DestroyObject()
    {
        base.DestroySelf();
    }
}
