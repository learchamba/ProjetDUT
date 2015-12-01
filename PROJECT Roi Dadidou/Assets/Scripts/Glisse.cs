using UnityEngine;
using System.Collections;

public class Glisse : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 4.0f; 
	bool moving = false;
	string direction = null;
	PlayerWalk player;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving == true) {
			if (direction == "right")
				pos.x++;
			if (direction == "left")
				pos.x--;
			if (direction == "up")
				pos.y++;
			if (direction == "down")
				pos.y--;

			transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		}

	}

	void OnCollisionExit2D(Collision2D collision){

		if (collision.gameObject.tag == "Player") {
			moving = true;
			player = collision.gameObject.GetComponent("PlayerWalk") as PlayerWalk ;
			direction = player.getLastInput();
		} else {
			moving = false;
			pos.x = Mathf.Round (transform.position.x);
			pos.y = Mathf.Round (transform.position.y);
			transform.position = pos;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		moving = false;
		pos.x = Mathf.Round (transform.position.x);
		pos.y = Mathf.Round (transform.position.y);
		transform.position = pos;
	}

	void OnCollisionStay2D(Collision2D collision){

	}

}
