using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	float oldScore;
	public static float score=0;
	int nbBloc;
	Vector2 collisionposition;
	Vector2 position;
	float startTimer;
	float time;
	SpriteRenderer sprite;
	GameObject exit;
	// Use this for initialization
	void Start () {
		oldScore = score ;
		startTimer = Time.time;
		exit = GameObject.FindGameObjectWithTag("Exit") ;
		sprite = exit.GetComponent("SpriteRenderer") as SpriteRenderer ;
		sprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( oldScore != score){
			print(oldScore+"->"+score);
			oldScore = score ;
		}
	
	}

	void OnTriggerStay2D (Collider2D collision){
		if (sprite.enabled==true){
			position.x = Mathf.Round(transform.position.x) ;
			position.y = Mathf.Round(transform.position.y) ;
			collisionposition.x = Mathf.Round(collision.gameObject.transform.position.x);
			collisionposition.y = Mathf.Round(collision.gameObject.transform.position.y);
			if ((collision.gameObject.tag =="Player")){
				if ((position.x == collisionposition.x) && (position.y == collisionposition.y)){
					Destroy(collision.gameObject);
					time =  Time.time - startTimer;
					nbBloc = GameObject.FindGameObjectsWithTag("Glisse").Length ;
					print(time.ToString() + " nb bloc : " + nbBloc.ToString());
					score += Mathf.Round(nbBloc *100 - time * 10);
					print ("score" + score);
				}
			}
		}
	}
}
