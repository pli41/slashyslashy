using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

    public GameObject ghostBall;
    public float attackInterval;
    public float alertDistance;
    public PlayerController playerCtrl;

    public bool alerted;

    float attackTimer;

	// Use this for initialization
	void Start () {
        alerted = false;
        attackTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
        HandleAttack();
	}

    void CheckDistance()
    {
        Debug.Log(Vector2.Distance(transform.position, playerCtrl.transform.position));
        if (Vector2.Distance(transform.position, playerCtrl.transform.position) < alertDistance)
        {
            alerted = true;
        }
        else
        {
            alerted = false;
        }
    }

    void HandleAttack()
    {
        if (alerted)
        {
            if (attackTimer < attackInterval)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                attackTimer = 0f;
                Instantiate(ghostBall, transform.position, transform.rotation);
                Debug.Log("Biu Biu Biu");
            }
        }
        
    }
}
