using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public PlayerController pc;
    public Animator weaponAnimator;
    public float attackSpeed; // Per second
    public bool attackReady;

    public Collider2D weaponCol;

    float attackSpeedTimer;


	// Use this for initialization
	void Start () {
        weaponCol.enabled = false;
        pc = transform.parent.GetComponent<PlayerController>();
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
            weaponCol.enabled = true;
            pc.PlayAudio(pc.attack);
            weaponAnimator.SetTrigger("Attack");
            Invoke("ResetAttack", 1f);
            attackReady = false;
        }
        
    }

    void ResetAttack()
    {
        //attacked = false;
        weaponCol.enabled = false;
        weaponAnimator.ResetTrigger("Attack");
    }

    
}
