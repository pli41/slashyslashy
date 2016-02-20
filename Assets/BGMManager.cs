using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

    AudioSource aus;

	// Use this for initialization
	void Start () {
        aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        aus.pitch = Time.timeScale;
	}
}
