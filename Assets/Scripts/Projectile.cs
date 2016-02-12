﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Rigidbody2D rigid;

    public int damage;
    public float horiSpeed;
    public float gravityScale;
    public float persistTime;

	// Use this for initialization
	void Start () {
        rigid.velocity = new Vector2(horiSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
