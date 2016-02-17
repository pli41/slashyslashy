using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public SpriteRenderer sr;
	public bool active;
	public Collider2D col;
	public Animator anim;
    public float blockStaminaCost;
    public PlayerController playerCtrl;


	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCollider ();
		UpdateAnimator ();
	}


	void UpdateCollider(){
		col.enabled = active;
	}

	void UpdateAnimator(){
        if (active)
        {
            sr.sortingOrder = 3;
        }
        else
        {
            sr.sortingOrder = 0;
        }
		anim.SetBool ("active", active);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "EnemyAttack"){
			col.GetComponent<EnemyAttack> ().DestroySelf ();
            playerCtrl.stamina -= blockStaminaCost;
            if (playerCtrl.stamina < 0)
            {
                playerCtrl.stamina = 0;
            }
		}
	}
}
