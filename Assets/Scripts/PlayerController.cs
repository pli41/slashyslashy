using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D rigid;

    public enum PlayerState{ Run, Attack, Jump, Def};
    public PlayerState state;

    public float MaxHoriSpeed;
    public float accelerationTime;


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

        HandleJump();
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
