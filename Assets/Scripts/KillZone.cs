using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().DisablePlayer();
            //SceneManager.LoadScene(LevelManager.currentLevel);
        }
        else if (col.tag == "Obstacle")
        {
            col.GetComponent<Destroyable>().StartDestroy();
        }
        else if (col.tag == "Enemy")
        {
            col.gameObject.SendMessage("DestroySelf");
        }
    }
}
