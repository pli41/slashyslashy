﻿using UnityEngine;
using System.Collections;

public class FrontChecker : MonoBehaviour {

    public PlayerController playerCtrl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Obstacle")
        {
            //Debug.Log("Colliding with " + col.gameObject.name);
            playerCtrl.state = PlayerController.PlayerState.Stun;
            playerCtrl.collider.enabled = false;
            playerCtrl.animator.SetTrigger("Stun");
            playerCtrl.Invoke("ReturnToRun", playerCtrl.stunRecoverTime);
        }
        else if (col.tag == "EnemyAttack") {
            //Debug.Log("666");
			EnemyAttack ep = col.GetComponent<EnemyAttack>();
            if (ep)
            {
                if (ep.active)
                {
					Debug.Log ("Damage received");
                    playerCtrl.HandleDamage(ep.damage);
                }
                
            }
            

        }


        
    }
}