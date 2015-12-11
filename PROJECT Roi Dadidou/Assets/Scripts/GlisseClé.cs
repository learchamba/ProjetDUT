using UnityEngine;
using System.Collections;

public class GlisseClé : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 4.0f; 
	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	string direction = null;
	PlayerWalk player;
	GameObject exit;
	Vector2 collisionposition;
	Vector2 position;
	int nbCoups = 5;
	SpriteRenderer sprite;
	public  static int nbBlocClé;
	public  int xExit;
	public  int yExit;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		nbBlocClé = GameObject.FindGameObjectsWithTag("GlisseClé").Length ;
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
		fonctCollision(false,collision);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		fonctCollision(true,collision);
		
		if (collision.gameObject.tag == "Player" ) {
			player = collision.gameObject.GetComponent("PlayerWalk") as PlayerWalk ;
			direction = player.getLastInput();
			
			if (direction == "right" && right ){
				fonctBlocDestruction();
			}
			if (direction == "left" && left){
				fonctBlocDestruction();
			}
			if (direction == "up" && up){
				fonctBlocDestruction();
			}
			if (direction == "down" && down){
				fonctBlocDestruction();
			}
		}else {
			if ((collisionposition.x > position.x) && (collisionposition.y == position.y)){
				if (direction == "right"){
					direction = null;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((collisionposition.x < position.x) && (collisionposition.y == position.y)){
				if (direction == "left"){
					direction = null;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((collisionposition.y > position.y) && (collisionposition.x == position.x)){
				if (direction == "up"){
					direction = null;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
			if ((collisionposition.y < position.y) && (collisionposition.x == position.x)){
				if (direction == "down"){
					direction = null;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
		}
	}
	
	public void fonctCollision(bool etat, Collision2D collision){
		position.x = Mathf.Round(transform.position.x) ;
		position.y = Mathf.Round(transform.position.y) ;
		collisionposition.x = Mathf.Round(collision.gameObject.transform.position.x);
		collisionposition.y = Mathf.Round(collision.gameObject.transform.position.y);
		if ((collisionposition.x > position.x) && (collisionposition.y == position.y)){
			right = etat;
		}
		if ((collisionposition.x < position.x) && (collisionposition.y == position.y)){
			left = etat;
		}
		if ((collisionposition.y > position.y) && (collisionposition.x == position.x)){
			up = etat;
		}
		if ((collisionposition.y < position.y) && (collisionposition.x == position.x)){
			down = etat;
		}
	}
	
	public void fonctBlocDestruction(){
		nbCoups--;
		if (nbCoups == 0){
			Destroy(gameObject);
			nbBlocClé--;
			if (nbBlocClé == 0){
				exit = GameObject.FindGameObjectWithTag("Exit") ;
				sprite = exit.GetComponent("SpriteRenderer") as SpriteRenderer ;
				sprite.enabled = true;
			}
		}
	}
}
