using UnityEngine;
using System.Collections;

public class Glisse : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 4.0f; 
	bool moving = false;
	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	string direction = null;
	PlayerWalk player;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			if (direction == "right" && !right )
				pos.x++;
			if (direction == "left" && !left)
				pos.x--;
			if (direction == "up" && !up)
				pos.y++;
			if (direction == "down" && !down)
				pos.y--;

			transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);

	}

	void OnCollisionExit2D(Collision2D collision){

		if (Mathf.Round(collision.gameObject.transform.position.x) > Mathf.Round(transform.position.x) )
			right = false;
		if (Mathf.Round(collision.gameObject.transform.position.x) < Mathf.Round(transform.position.x))
			left = false;
		if (Mathf.Round(collision.gameObject.transform.position.y) > Mathf.Round(transform.position.y) )
			up = false;
		if (Mathf.Round(collision.gameObject.transform.position.y) < Mathf.Round(transform.position.y))
			down =false;
	}

	void OnCollisionEnter2D(Collision2D collision){

		if ((Mathf.Round(collision.gameObject.transform.position.x) > Mathf.Round(transform.position.x)) && (Mathf.Round(collision.gameObject.transform.position.y) == Mathf.Round(transform.position.y)) ){
			right = true;
		}
		if ((Mathf.Round(collision.gameObject.transform.position.x) < Mathf.Round(transform.position.x)) && (Mathf.Round(collision.gameObject.transform.position.y) == Mathf.Round(transform.position.y)) ){
			left = true;
		}
		if ((Mathf.Round(collision.gameObject.transform.position.y) > Mathf.Round(transform.position.y)) && (Mathf.Round(collision.gameObject.transform.position.x) == Mathf.Round(transform.position.x)) ){
			up = true;
		}
		if ((Mathf.Round(collision.gameObject.transform.position.y) < Mathf.Round(transform.position.y)) && (Mathf.Round(collision.gameObject.transform.position.x) == Mathf.Round(transform.position.x)) ){
			down = true;
		}

		if (collision.gameObject.tag == "Player" ) {
			player = collision.gameObject.GetComponent("PlayerWalk") as PlayerWalk ;
			direction = player.getLastInput();
		}else {
			if ((Mathf.Round(collision.gameObject.transform.position.x) > Mathf.Round(transform.position.x)) && (Mathf.Round(collision.gameObject.transform.position.y) == Mathf.Round(transform.position.y)) ){
				if (direction == "right"){
					direction = null;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((Mathf.Round(collision.gameObject.transform.position.x) < Mathf.Round(transform.position.x)) && (Mathf.Round(collision.gameObject.transform.position.y) == Mathf.Round(transform.position.y)) ){
				if (direction == "left"){
					direction = null;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((Mathf.Round(collision.gameObject.transform.position.y) > Mathf.Round(transform.position.y)) && (Mathf.Round(collision.gameObject.transform.position.x) == Mathf.Round(transform.position.x)) ){
				if (direction == "up"){
					direction = null;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
			if ((Mathf.Round(collision.gameObject.transform.position.y) < Mathf.Round(transform.position.y)) && (Mathf.Round(collision.gameObject.transform.position.x) == Mathf.Round(transform.position.x)) ){
				if (direction == "down"){
					direction = null;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
		}
	}



}
