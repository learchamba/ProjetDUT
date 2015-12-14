using UnityEngine;
using System.Collections;

public class Patroller : MonoBehaviour {
	public Vector3 pos;
	public float speed = 2.0f;
	int time = 0;
	public int width;
	public int height;
	public float xspawn;
	public float yspawn;
	float tamponx;
	float tampony;
	public float xtarget;
	public float ytarget;
	public Animator anim;
	void Start () {
		pos = transform.position; 
		xspawn = pos.x;
		yspawn = pos.y;
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		if (transform.position == pos){
			if(xtarget > xspawn){
				if ( Mathf.Round (transform.position.x) < xtarget){
					transform.localScale = new Vector3 (-5, 5, 1);
					anim.SetInteger("AnimState",1);
					pos.x ++;
					time = 0;
				}
				else{
					tamponx = xtarget;
					xtarget = xspawn;
					xspawn = tamponx;
				}
			}

			if(xtarget <= xspawn){
				if ( Mathf.Round (transform.position.x) > xtarget){
					pos.x--;
					transform.localScale = new Vector3 (5, 5, 1);
					anim.SetInteger("AnimState",1);
					time = 0;
				}else{
					tamponx = xtarget;
					xtarget = xspawn;
					xspawn = tamponx;
				}
			}

			if(ytarget > yspawn){
				if ( Mathf.Round (transform.position.y) < ytarget){
					anim.SetInteger("AnimState",2);
					pos.y ++;
					time = 0;
				}
				else{

					tampony = ytarget;
					ytarget = yspawn;
					yspawn = tampony;
				}
			}

			if(ytarget <= yspawn){
				if ( Mathf.Round (transform.position.y) > ytarget){
					anim.SetInteger("AnimState",3);
					pos.y --;
					time = 0;
				}
				else{

					tampony = ytarget;
					ytarget = yspawn;
					yspawn = tampony;
				}
			}

		}
		time++;
		if (time == 15) {
			pos.x = Mathf.Round (transform.position.x);
			pos.y = Mathf.Round (transform.position.y);
		}
		else
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (!(collision.gameObject.tag =="Wall")){
			if (Mathf.Round(collision.transform.position.y) == Mathf.Round(pos.y)){
				tamponx = xtarget;
				xtarget = xspawn;
				xspawn = tamponx;
			}

			if (Mathf.Round(collision.transform.position.x) == Mathf.Round(pos.x)){
				tampony = ytarget;
				ytarget = yspawn;
				yspawn = tampony;
			}
		}

		if (collision.gameObject.tag=="Player"){
			if ((Mathf.Round(collision.transform.position.y) == Mathf.Round(pos.y)) || (Mathf.Round(collision.transform.position.x) == Mathf.Round(pos.x)) ){
				Destroy(collision.gameObject);
			}
		}
	}
}
