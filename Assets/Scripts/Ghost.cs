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

    public AudioClip death;
    public AudioClip attack;

    AudioSource aus;

	// Use this for initialization
	void Start () {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        active = true;
        alerted = false;
        attackTimer = 0f;
        attackReady = true;
        aus = GetComponent<AudioSource>();
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
        PlayAudio(death);
        Invoke("DestroyObject", 1f);
    }

    public void DestroyObject()
    {
        base.DestroySelf();
    }

    public void PlayAudio(AudioClip clip)
    {
        aus.Stop();
        aus.PlayOneShot(clip);
    }
}
