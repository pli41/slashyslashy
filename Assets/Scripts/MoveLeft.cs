using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

    public PlayerController playerCtrl;
    public Rigidbody2D rigid;

    public float runSpeed;
    public float attSpeed;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerCtrl.state == PlayerController.PlayerState.Run)
        {
            moveSpeed = runSpeed;
        }
        else if (playerCtrl.state == PlayerController.PlayerState.Attack || playerCtrl.state == PlayerController.PlayerState.Def) 
        {
            moveSpeed = attSpeed;
        }
        Move();
        
	}

    void Move()
    {
        Vector2 currentPos = transform.position;
        currentPos = new Vector2(currentPos.x - moveSpeed*Time.deltaTime, currentPos.y);
        transform.position = currentPos;
    }
}
