using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Rigidbody rigid;

    public float damage;
    public float horiSpeed;
    public float gravityScale;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
