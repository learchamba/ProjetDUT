using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 2.0f;                         // Speed of movement
	public int width;
	public int height;
	
	void Start () {
		pos = transform.position;          // Take the initial position
	}
	
	void FixedUpdate () {
		if((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)) && transform.position == pos && pos.x > 1 ) {        // Left
			pos += Vector3.left;
		}
		if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position == pos && pos.x < width - 2) {        // Right
			pos += Vector3.right;
		}
		if((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)) && transform.position == pos && pos.y < height -2) {        // Up
			pos += Vector3.up;
		}
		if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position == pos & pos.y > 1) {        // Down
			pos += Vector3.down;
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
	}
}
