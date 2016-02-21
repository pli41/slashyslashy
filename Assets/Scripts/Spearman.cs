using UnityEngine;
using System.Collections;

public class Spearman : Enemy {

    public GameObject player;
    public Rigidbody2D rigid;
    public float MaxHoriSpeed;
    public float horiForce;
    public Vector2 receiveForceByAttack;

    public bool stopped;
    public float stopRecoverTime;

    public Animator anim;

    public float alertDistance;

    public bool damageable;
    public float damageResetTime;
    public bool stopCheck;


	// Use this for initialization
    void Awake()
    {
        damageable = true;
        stopped = true;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

	void Start () {
        active = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (stopped && !stopCheck)
        {
            CheckDistance();
        }
        
	}

    void CheckDistance()
    {
        if (player)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < alertDistance)
            {
                stopped = false;
                stopCheck = true;
            }
        }

        //Debug.Log(Vector2.Distance(transform.position, playerCtrl.transform.position));

    }

    void FixedUpdate()
    {
        if (!stopped)
        {
            rigid.velocity = new Vector2(MaxHoriSpeed, rigid.velocity.y);
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
        Debug.Log("Recovered");
        stopped = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (active && ! stopped)
        {
            if (col.tag == "Player")
            {

                if (col.name == "Shield")
                {
                    PlayerController pc = col.transform.parent.GetComponent<PlayerController>();
                    pc.state = PlayerController.PlayerState.onHit;
                    //Debug.Break();
                    col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
                    if (!stopped)
                    {
                        stopped = true;
                        Debug.Log("Spearman Stopped;");
                        Invoke("StopRecover", stopRecoverTime);
                    }
                }

                else if (col.name == "FrontCheck")
                {
                    Debug.Log("Collide with front check");
                    //Debug.Break();
                    PlayerController pc = col.transform.parent.GetComponent<PlayerController>();
                    col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
                    if (pc.state != PlayerController.PlayerState.Def)
                    {
                        pc.state = PlayerController.PlayerState.Stun;
                        pc.HandleDamage(damage);
                    }
                    if (!stopped)
                    {
                        stopped = true;
                        Debug.Log("Spearman Stopped;");
                        Invoke("StopRecover", stopRecoverTime);
                    }
                }
            }
            else if (col.tag == "Obstacle")
            {
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
            }
        }
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (active && !stopped)
    //    {
    //        if (col.tag == "Player")
    //        {


    //            if (col.name == "Shield")
    //            {
    //                PlayerController pc = col.transform.parent.GetComponent<PlayerController>();
    //                pc.state = PlayerController.PlayerState.onHit;
    //                Debug.Break();
    //                col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
    //            }

    //            else if (col.name == "FrontCheck")
    //            {
    //                Debug.Log("Collide with front check");
    //                //Debug.Break();
    //                PlayerController pc = col.transform.parent.GetComponent<PlayerController>();
    //                col.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiForce, 100f));
    //                if (pc.state != PlayerController.PlayerState.Def)
    //                {
    //                    pc.state = PlayerController.PlayerState.Stun;
    //                    pc.HandleDamage(damage);
    //                }
    //            }

    //            if (!stopped)
    //            {
    //                stopped = true;
    //                Invoke("StopRecover", stopRecoverTime);
    //            }


    //        }
    //    }
    //}
}
