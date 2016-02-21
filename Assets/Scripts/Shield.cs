using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public SpriteRenderer sr;
	public bool active;
	public Collider2D col;
	public Animator anim;
    public float blockStaminaCost;
    public PlayerController playerCtrl;

    public AudioClip block;

    public bool blockInvoked;

    AudioSource aus;

	// Use this for initialization
	void Start () {
		active = false;
        aus = GetComponent<AudioSource>();
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
            //playerCtrl.stamina -= blockStaminaCost;
            //if (playerCtrl.stamina < 0)
            //{
            //    playerCtrl.stamina = 0;
            //    playerCtrl.state = PlayerController.PlayerState.Run;
            //}


            col.GetComponent<EnemyAttack>().DestroySelf();
            anim.SetTrigger("Block");
            if (!blockInvoked)
            {
                Invoke("ResetTrigger", 0.5f);
                blockInvoked = true;
            }
            PlayAudio(block);
			
            
		}
	}

    void PlayAudio(AudioClip clip)
    {
        aus.Stop();
        aus.PlayOneShot(clip);
        
    }

    void ResetTrigger()
    {
        blockInvoked = false;
        anim.ResetTrigger("Block");
    }
}
