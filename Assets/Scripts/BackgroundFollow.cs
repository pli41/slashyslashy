using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {

    public float XOffset;
    public float YOffset;
    public Transform playerT;

    public float maxScrollingSpeed;

    public float scrollingSpeed;
    public MeshRenderer rend;
    public PlayerController pc;

    public GameManager gm;

    public float scrollOffset;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //adjust scrollings speed
        if (gm.isMainMenu)
        {
            scrollingSpeed = maxScrollingSpeed;
        }
        else
        {
            if (pc)
            {
                scrollingSpeed = pc.currentSpeed.x / pc.MaxHoriSpeed * maxScrollingSpeed;
            }
            else
            {
                scrollingSpeed = 0;
            }
        }
        

        if (playerT)
        {
            Vector3 newPos = new Vector3(playerT.position.x + XOffset, transform.position.y, 0);
            transform.position = newPos;
        }
        

        scrollOffset += Time.deltaTime * scrollingSpeed;

        Vector2 offset = new Vector2(scrollOffset, 0);
        rend.material.mainTextureOffset = offset;

        
	}
}
