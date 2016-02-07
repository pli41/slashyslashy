using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {

 //   public GameObject target;

 //   public float MaxFollowingSpeed;
    


	//// Use this for initialization
	//void Start () {
	    
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       if (CheckDistanceToTarget())
 //       {
 //           transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MaxFollowingSpeed);
 //           transform.position = new Vector3(transform.position.x, 1, -10);
 //       }
	//}


 //   /// <summary>
 //   /// Checks distance from camera to target
 //   /// </summary>
 //   /// <returns>returns true when too far; vise versa</returns>
 //   bool CheckDistanceToTarget()
 //   {
 //       float distance = Vector2.Distance(transform.position, target.transform.position);
 //       if (distance > 0.1f)
 //       {
 //           return true;
 //       }
 //       else
 //       {
 //           return false;
 //       }
 //   }

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float XOffsetOnScreen;
    public float YOffsetOnScreen;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(XOffsetOnScreen, YOffsetOnScreen, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }




}
