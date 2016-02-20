using UnityEngine;
using System.Collections;

public class Ghost : Enemy {

    public GameObject ghostBall;
    public float attackInterval;
    public float alertDistance;
    public PlayerController playerCtrl;
    public Animator anim;

    public bool alerted;
    public bool attackReady;
    float attackTimer;

	// Use this for initialization
	void Start () {
        active = true;
        alerted = false;
        attackTimer = 0f;
        attackReady = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            CheckDistance();
            HandleAttack();
        }
	}

    void CheckDistance()
    {
        if (playerCtrl)
        {
            if (Vector2.Distance(transform.position, playerCtrl.transform.position) < alertDistance)
            {
                alerted = true;
            }
            else
            {
                alerted = false;
            }
        }

        //Debug.Log(Vector2.Distance(transform.position, playerCtrl.transform.position));
        
    }

    void HandleAttack()
    {
        if (alerted)
        {
            if (!attackReady)
            {
                if (attackTimer < attackInterval)
                {
                    attackTimer += Time.deltaTime;
                }
                else
                {
                    attackTimer = 0f;
                    attackReady = true;
                }
            }
            else
            {
                attackReady = false;
                Attack();
            }
            
        }
    }

    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
    }

    public override void Attack()
    {
        Instantiate(ghostBall, transform.position, transform.rotation);
    }

    public override void DestroySelf()
    {
        Debug.Log(gameObject + " starts to destroy itself");
        active = false;
        anim.SetTrigger("Die");
        Invoke("DestroyObject", 2f);
    }

    public void DestroyObject()
    {
        base.DestroySelf();
    }
}
