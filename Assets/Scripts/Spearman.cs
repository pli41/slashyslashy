using UnityEngine;
using System.Collections;

public class Spearman : Enemy {

    public Rigidbody2D rigid;
    public float MaxHoriSpeed;
    public float horiForce;
    public Vector2 receiveForceByAttack;

    public bool stopped;
    public float stopRecoverTime;

    public Animator anim;

    public bool damageable;
    public float damageResetTime;

	// Use this for initialization
    void Awake()
    {
        damageable = true;
        stopped = false;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	void Start () {
        active = true;
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (!stopped)
        {
            rigid.velocity = new Vector2(MaxHoriSpeed, 0f);
        }
        
    }

    public override void ReceiveDamage(int damage)
    {
        if (damageable)
        {
            Debug.Log("Receive damage");
            base.ReceiveDamage(damage);
            anim.SetTrigger("Damage");
            rigid.AddForce(receiveForceByAttack);
            damageable = false;
            Invoke("ResetDamageable", damageResetTime);
        }
        
    }

    public void ResetDamageable()
    {
        damageable = true;
    }

    public override void DestroySelf()
    {
        anim.SetTrigger("Die");
        Invoke("DestroyObject", anim.GetCurrentAnimatorStateInfo(0).length);
    }

    public void DestroyObject()
    {
        base.DestroySelf();
    }

    void StopRecover()
    {
        stopped = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (active && ! stopped)
        {
            if (col.tag == "Player")
            {
                if (col.name == "FrontCheck")
                {
                    Debug.Log("Collide with front check");

                    col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
                    PlayerController pc = col.transform.parent.GetComponent<PlayerController>();
                    

                    if (pc.state != PlayerController.PlayerState.Def)
                    {
                        pc.state = PlayerController.PlayerState.Stun;
                        pc.HandleDamage(damage);
                    }
                    pc.state = PlayerController.PlayerState.onHit;

                    if (!stopped)
                    {
                        stopped = true;
                        Invoke("StopRecover", stopRecoverTime);
                    }
                    
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (active && !stopped)
        {
            if (col.tag == "Player")
            {
                if (col.name == "FrontCheck")
                {
                    Debug.Log("Collide with front check");

                    col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
                    PlayerController pc = col.transform.parent.GetComponent<PlayerController>();


                    if (pc.state != PlayerController.PlayerState.Def)
                    {
                        pc.state = PlayerController.PlayerState.Stun;
                        pc.HandleDamage(damage);
                    }
                    pc.state = PlayerController.PlayerState.onHit;

                    if (!stopped)
                    {
                        stopped = true;
                        Invoke("StopRecover", stopRecoverTime);
                    }

                }


            }
        }
    }
}
