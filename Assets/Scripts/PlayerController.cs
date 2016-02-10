using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D rigid;

    public enum PlayerState{ Run, Attack, Jump, Def, Stun};
    public PlayerState state;

    public float attackMoveSpeed;
    public GameObject attackObject;
    public float attackTime;

    public float MaxHoriSpeed;
    public float accelerationTime;

    public float stunRecoverTime;
    public Collider2D collider;

    public float currentAccTime;
    public bool recovering;
    public Collider groundChecker;


    public bool grounded;
    public bool inAir;
    public float inAirGravityScale;
    public float onGroundGravityScale;
    public Vector2 jumpForce;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

	// Use this for initialization
	void Start () {
        currentAccTime = 0f;
        grounded = false;
        inAir = false;
	}
	


	// Update is called once per frame
	void Update () {
        if (state == PlayerState.Run)
        {
            rigid.velocity = RecoverSpeed();
        }
        else if(state == PlayerState.Attack)
        {

        }
        else if (state == PlayerState.Jump)
        {
            rigid.gravityScale = inAirGravityScale;
        }
        else if (state == PlayerState.Def)
        {

        }
        else if (state == PlayerState.Stun)
        {
            rigid.velocity = new Vector2(0, 0);
        }
        HandleAttack();
        HandleJump();
    }

    void HandleStun()
    {

    }

    void HandleAttack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            //CancelInvoke();
            rigid.velocity = new Vector2(attackMoveSpeed, 0);
            Instantiate(attackObject, transform.position, transform.rotation);
            state = PlayerState.Attack;
            Invoke("ReturnToRun", attackTime);
        }
    }

    void StartReturningToRun(float time)
    {
        Invoke("ReturnToTun", time);
    }

    void ReturnToRun()
    {
        state = PlayerState.Run;
        if (!collider.enabled)
        {
            collider.enabled = true;
        }
        animator.SetTrigger("ReturnToRun");
    }

    void HandleJump()
    {
        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (!inAir)
                {
                    Debug.Log("Jump");
                    rigid.AddForce(jumpForce);
                    inAir = true;
                    grounded = false;
                    state = PlayerState.Jump;
                    rigid.gravityScale = inAirGravityScale;
                }
            }
        }

        if (inAir)
        {
            if (grounded)
            {
                inAir = false;
                state = PlayerState.Run;
                rigid.gravityScale = onGroundGravityScale;
            }
        }
    }

    Vector2 RecoverSpeed()
    {
        if (rigid.velocity.x < MaxHoriSpeed)
        {
            HandleRecoveryAccTime();
        }
        Vector2 currentVelo = rigid.velocity;
        Vector2 nextStepVelo = Vector2.Lerp(currentVelo, new Vector2(MaxHoriSpeed, rigid.velocity.y), currentAccTime);
        return nextStepVelo;
    }

    void HandleRecoveryAccTime()
    {
        if (currentAccTime < 1f)
        {
            currentAccTime += Time.deltaTime;
        }
    }

}
