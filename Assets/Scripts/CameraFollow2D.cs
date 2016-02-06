using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {

    public GameObject target;

    public float MaxFollowingSpeed;
    


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckDistanceToTarget())
        {

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MaxFollowingSpeed);
            transform.position = new Vector3(transform.position.x, 1, -10);
        }
	}


    /// <summary>
    /// Checks distance from camera to target
    /// </summary>
    /// <returns>returns true when too far; vise versa</returns>
    bool CheckDistanceToTarget()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
