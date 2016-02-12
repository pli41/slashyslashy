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
        Debug.Log("collide");
        AnimateAndDestroy();
    }

    void AnimateAndDestroy()
    {
        active = false;
        animator.SetTrigger("Destroy");
    }
}
