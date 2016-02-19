using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {

    public float XOffset;
    public float YOffset;
    public Transform playerT;

    public float scrollingSpeed;
    public MeshRenderer rend;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(playerT.position.x + XOffset, transform.position.y, 0);
        transform.position = newPos;

        Vector2 offset = new Vector2(Time.time * scrollingSpeed, 0);
        rend.material.mainTextureOffset = offset;
	}
}
