using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour {
	Vector3 pos;                                // For movement
	public float speed = 2.0f;                         // Speed of movement
	public int time = 0;
	public int width;
	public int height;
	string lastInput;
	public Animator Anim;
	void Start () {
		pos = transform.position;          // Take the initial position
		Anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		if ((Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.LeftArrow)) && transform.position == pos) {        // Left
			Anim.SetInteger ("AnimState", 1);
			pos += Vector3.left;
			lastInput = "left";
			time = 0;
			transform.localScale = new Vector3 (-2.5f, 2.5f, 1);
		} else if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && transform.position == pos) {        // Right
			Anim.SetInteger ("AnimState", 1);
			pos += Vector3.right;
			lastInput = "right";
			time = 0;
			transform.localScale = new Vector3 (2.5f, 2.5f, 1);
		} else if ((Input.GetKey (KeyCode.Z) || Input.GetKey (KeyCode.UpArrow)) && transform.position == pos) {        // Up
			Anim.SetInteger ("AnimState", 2);
			pos += Vector3.up;
			lastInput = "up";
			time = 0;
		} else 	if ((Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) && transform.position == pos) {        // Down
			Anim.SetInteger ("AnimState", 3);
			pos += Vector3.down;
			lastInput = "down";
			time = 0;
		} else if (transform.position == pos) {
			Anim.SetInteger ("AnimState", 0);
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
