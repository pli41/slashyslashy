using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    public PlayerController playerCtrl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
           playerCtrl.GetComponent<PlayerController>().grounded = true;
        }
    }
}
