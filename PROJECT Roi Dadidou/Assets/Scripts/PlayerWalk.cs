using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 2.0f;                         // Speed of movement
	int time = 0;
	public int width;
	public int height;
	string lastInput;
	
	void Start () {
		pos = transform.position;          // Take the initial position
	}
	
	void FixedUpdate () {
		if((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)) && transform.position == pos  ) {        // Left
			pos += Vector3.left;
			lastInput="left";
			time = 0;
		}
		if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position == pos ) {        // Right
			pos += Vector3.right;
			lastInput="right";
			time = 0;
		}
		if((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)) && transform.position == pos ) {        // Up
			pos += Vector3.up;
			lastInput="up";
			time = 0;
		}
		if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position == pos ) {        // Down
			pos += Vector3.down;
			lastInput="down";
			time = 0;
		}
		time++;
		if (time == 15) {
			pos.x = Mathf.Round (transform.position.x);
			pos.y = Mathf.Round (transform.position.y);
		}
		else
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
	}

	public string getLastInput(){
		return lastInput;
	}
}
