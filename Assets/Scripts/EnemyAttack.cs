using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public bool active;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void DestroySelf()
	{
		Destroy(gameObject);
	}
}
