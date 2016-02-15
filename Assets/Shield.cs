using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public bool active;
	public Collider2D col;
	public Animator anim;

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
		anim.SetBool ("active", active);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "EnemyAttack"){
			col.GetComponent<EnemyAttack> ().DestroySelf ();
		}
	}
}
