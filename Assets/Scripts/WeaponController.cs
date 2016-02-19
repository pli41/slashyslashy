using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public Animator weaponAnimator;
    public float attackSpeed; // Per second
    public bool attackReady;

    float attackSpeedTimer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!attackReady)
        {
            if (attackSpeedTimer < 1f / attackSpeed)
            {
                attackSpeedTimer += Time.deltaTime;
            }
            else
            {
                attackReady = true;
                attackSpeedTimer = 0;
            }
        }

        
	}

    public void Attack()
    {
        if (attackReady)
        {
            weaponAnimator.SetTrigger("Attack");
            Invoke("ResetAttack", 0.5f);
            attackReady = false;
        }
        
    }

    void ResetAttack()
    {
        weaponAnimator.ResetTrigger("Attack");
    }

    
}
