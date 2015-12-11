using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	float startTimer;
	SpriteRenderer sprite;
	GameObject exit;
	// Use this for initialization
	void Start () {
		startTimer = Time.time;
		exit = GameObject.FindGameObjectWithTag("Exit") ;
		sprite = exit.GetComponent("SpriteRenderer") as SpriteRenderer ;
		sprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
