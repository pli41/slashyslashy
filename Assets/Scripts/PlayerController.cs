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

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        currentAccTime = 0f;

	}
	


	// Update is called once per frame
	void Update () {
        if (state == PlayerState.Run)
        {
            
        }
        else if(state == PlayerState.Attack)
        {

        }
        else if (state == PlayerState.Jump)
        {

        }
        else if (state == PlayerState.Def)
        {

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
