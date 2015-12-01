using UnityEngine;
using System.Collections;

public class Glisse : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 4.0f; 
	bool moving = false;
	string direction;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving == true) {
			if (direction == "droite")
				pos.x++;
			if (direction == "gauche")
				pos.x--;
			if (direction == "haut")
				pos.y++;
			if (direction == "bas")
				pos.y--;

			transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		}
	}

	void OnCollisionExit2D(Collision2D collision){

		if (collision.gameObject.tag == "Player") {
			moving = true;
			if (collision.gameObject.transform.position.x < pos.x) {
				direction="droite";
			}

			if (collision.gameObject.transform.position.y < pos.y) {
				direction="haut";
			} 

			if (collision.gameObject.transform.position.x > pos.x) {
				direction="gauche";
			}
			
			if (collision.gameObject.transform.position.y > pos.y) {
				direction="bas";
			}
		} else {
			pos.x = Mathf.Round (transform.position.x);
			pos.y = Mathf.Round (transform.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		moving = false;
		pos.x = Mathf.Round (transform.position.x);
		pos.y = Mathf.Round (transform.position.y);
	}

}
