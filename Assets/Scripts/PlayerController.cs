using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public Animator weaponAnimator;

    public WeaponController weaponC;

    public Rigidbody2D rigid;

    public enum PlayerState{ Run, Attack, Jump, Def, Stun};
    public PlayerState state;

    public float attackMoveSpeed;
    public GameObject attackObject;
	public GameObject shield;
    public float attackTime;
    public float attackStaminaCost;
    public float defStaminaSpeed;

    public float MaxHoriSpeed;
    public float accelerationTime;

    public float stunRecoverTime;
    public Collider2D collider;

    public float currentAccTime;
    public bool recovering;

    //0-100
    public float stamina;
    public Slider staminaSlider;
    public float staminaRecoverySpeed;
   


    public bool grounded;
    public bool inAir;
    public float inAirGravityScale;
    public float onGroundGravityScale;
    public Vector2 jumpForce;

    public float currentDefPower;
    public bool isDead;

    public Vector2 currentSpeed;
    public bool locked;

    bool lockInvoked;

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
	

    void FixedUpdate()
    {
        if (!locked)
        {
            if (state == PlayerState.Run)
            {
                rigid.velocity = new Vector2(MaxHoriSpeed, rigid.velocity.y);
                //rigid.velocity = RecoverSpeed();
            }
            else if (state == PlayerState.Attack)
            {
                rigid.velocity = new Vector2(attackMoveSpeed, rigid.velocity.y);
            }
            else if (state == PlayerState.Jump)
            {
                rigid.gravityScale = inAirGravityScale;
            }
            else if (state == PlayerState.Def)
            {
                rigid.velocity = new Vector2(MaxHoriSpeed / 2f, rigid.velocity.y);
            }
            else if (state == PlayerState.Stun)
            {
                Debug.Log("Stunned");
                rigid.velocity = new Vector2(0, 0);
                locked = true;
                if (!lockInvoked)
                {
                    Invoke("Unlock", stunRecoverTime);
                    lockInvoked = true;
                }
                
            }
        }

        
    }

	// Update is called once per frame
	void Update () {
        currentSpeed = rigid.velocity;

        if (state == PlayerState.Run)
        {

        }
        else if (state == PlayerState.Attack)
        {

        }
        else if (state == PlayerState.Jump)
        {

        }
        else if (state == PlayerState.Def)
        {

        }
        else if (state == PlayerState.Stun)
        {
            Debug.Log("Stunned");
            locked = true;
            Invoke("Unlock", stunRecoverTime);
        }



        if (!locked)
        {
            HandleAttack();
            HandleAbility();
            HandleJump();
            HandleDef();
        }
        HandleDeath();
        HandleStamina();
    }

    public void HandleLock()
    {

    }

    public void Unlock()
    {
        lockInvoked = false;
        Debug.Log("Unlock");
        locked = false;
        ReturnToRun();
    }

    public void HandleStamina()
    {
        staminaSlider.value = stamina;
        if (stamina+ staminaRecoverySpeed * Time.deltaTime > 100)
        {
            stamina = 100;
        }
        else
        {
            stamina += staminaRecoverySpeed * Time.deltaTime;
        }
    }

    public bool CheckStamina(float amount)
    {
        if (amount <= stamina)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	public void HandleDef(){
        if (CheckStamina(defStaminaSpeed*Time.deltaTime))
        {
            if (Input.GetButton("Def"))
            {

                state = PlayerState.Def;
                shield.GetComponent<Shield>().active = true;
                stamina -= defStaminaSpeed * Time.deltaTime;
            }
            if(Input.GetButtonUp("Def"))
            {
                state = PlayerState.Run;
                shield.GetComponent<Shield>().active = false;
            }
        }
		
	}

    public void HandleDamage(int amount)
    {
        Debug.Log("get " + amount + "damage");
        if (currentDefPower-amount < 0f)
        {
            isDead = true;
        }
    }

    void HandleDeath()
    {
        if (isDead)
        {
            animator.SetTrigger("Die");
            Invoke("DisablePlayer", 0.5f);

        }
    }

    void HandleStun()
    {

    }

    void HandleAttack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            //Debug.Log("Attack");
            weaponC.Attack();
            state = PlayerState.Attack;
            Invoke("ReturnToRun", attackTime);
        }
    }

    void HandleAbility()
    {
        if (CheckStamina(attackStaminaCost))
        {
            if (Input.GetButtonDown("Ability1"))
            {
                //CancelInvoke();
                
                Instantiate(attackObject, transform.position, transform.rotation);
                state = PlayerState.Attack;
                Invoke("ReturnToRun", attackTime);
                stamina -= attackStaminaCost;
            }
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
        //recovering = rigid.velocity.x < MaxHoriSpeed;

        //if (recovering)
        //{
        //    //HandleRecoveryAccTime();
        //    Vector2 currentVelo = rigid.velocity;
        //    //Vector2 nextStepVelo = Vector2.Lerp(currentVelo, new Vector2(MaxHoriSpeed, rigid.velocity.y), currentAccTime);
        //    //return nextStepVelo;

        //    return Vector2.MoveTowards(currentVelo, new Vector2(MaxHoriSpeed, rigid.velocity.y), 0.2f);

        //}

        //else
        //{
        //    return new Vector2(MaxHoriSpeed, rigid.velocity.y);
        //}

        if (rigid.velocity.x < MaxHoriSpeed)
        {
            return Vector2.MoveTowards(rigid.velocity, new Vector2(MaxHoriSpeed, rigid.velocity.y), 0.1f);
        }
        else
        {
            Debug.Log("max speed");
            return rigid.velocity;
        }
        

    }

    void HandleRecoveryAccTime()
    {
        if (currentAccTime <= 1f)
        {
            currentAccTime += Time.deltaTime;
        }
    }

    void DisablePlayer()
    {
        Destroy(gameObject);
    }

}
