using UnityEngine;
using System.Collections;

public class GlisseClé : MonoBehaviour {
	Vector3 pos;                                // For movement
	float speed = 4.0f; 
	public bool left = false;
	public bool right = false;
	public bool up = false;
	public bool down = false;
	bool moving = false;
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
		if (direction == "right" && !right ){
			pos.x++;
		}
		if (direction == "left" && !left){
			pos.x--;
		}
		if (direction == "up" && !up){
			pos.y++;}
		
		if (direction == "down" && !down){
			pos.y--;
		}
		
		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		
	}
	
	void OnCollisionExit2D(Collision2D collision){
		fonctCollisionExit(collision);
	}
	
	void OnCollisionStay2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Enemy" ){
			if (moving == true){
				fonctCollisionDestruction(collision);
			}
		}
		if (moving == true) {
			fonctCollisionExit(collision);
		}
		else{
			fonctCollisionEnter(collision);
		}

		
	}
	
	
	void OnCollisionEnter2D(Collision2D collision){
		
		
		
		
		if (collision.gameObject.tag == "Player" ) {
			player = collision.gameObject.GetComponent("PlayerWalk") as PlayerWalk ;
			direction = player.getLastInput();
			if (direction == "right" && right ){
				fonctBlocDestruction();
			}
			else if (direction == "left" && left){
				fonctBlocDestruction();
			}
			else if (direction == "up" && up){
				fonctBlocDestruction();
			}
			else if (direction == "down" && down){
				fonctBlocDestruction();
			}
			else{
				moving = true;
			}
		}
		else if (collision.gameObject.tag == "Enemy" ){
			if (moving == true){
				fonctCollisionDestruction(collision);
			}
		}
		else	{
			fonctCollisionEnter(collision);
			if ((collisionposition.x > position.x) && (collisionposition.y == position.y)){
				if (direction == "right"){
					direction = null;
					moving = false;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((collisionposition.x < position.x) && (collisionposition.y == position.y)){
				if (direction == "left"){
					direction = null;
					moving = false;
					pos.x = Mathf.Round (transform.position.x);
				}
			}
			if ((collisionposition.y > position.y) && (collisionposition.x == position.x)){
				if (direction == "up"){
					direction = null;
					moving = false;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
			if ((collisionposition.y < position.y) && (collisionposition.x == position.x)){
				if (direction == "down"){
					direction = null;
					moving = false;
					pos.y = Mathf.Round (transform.position.y);
				}
			}
		}
	}
	
	public void fonctCollisionEnter(Collision2D collision){
		if (collision.gameObject.tag != "Ennemy"){
			position.x = Mathf.Round(transform.position.x) ;
			position.y = Mathf.Round(transform.position.y) ;
			collisionposition.x = Mathf.Round(collision.gameObject.transform.position.x);
			collisionposition.y = Mathf.Round(collision.gameObject.transform.position.y);
			if ((collisionposition.x > position.x) && (collisionposition.y == position.y)){
				right = true;
			}
			if ((collisionposition.x < position.x) && (collisionposition.y == position.y)){
				left = true;
			}
			if ((collisionposition.y > position.y) && (collisionposition.x == position.x)){
				up = true;
			}
			if ((collisionposition.y < position.y) && (collisionposition.x == position.x)){
				down = true;
			}
		}
	}
	
	public void fonctCollisionExit(Collision2D collision){
		position.x = Mathf.Round(transform.position.x) ;
		position.y = Mathf.Round(transform.position.y) ;
		collisionposition.x = Mathf.Round(collision.gameObject.transform.position.x);
		collisionposition.y = Mathf.Round(collision.gameObject.transform.position.y);
		if ((collisionposition.x > position.x)){
			right = false;
		}
		if ((collisionposition.x < position.x)){
			left = false;
		}
		if ((collisionposition.y > position.y)){
			up = false;
		}
		if ((collisionposition.y < position.y)){
			down = false;
		}
	}
	
	public void fonctCollisionDestruction(Collision2D collision){
		position.x = Mathf.Round(transform.position.x) ;
		position.y = Mathf.Round(transform.position.y) ;
		collisionposition.x = Mathf.Round(collision.gameObject.transform.position.x);
		collisionposition.y = Mathf.Round(collision.gameObject.transform.position.y);
		if ((collisionposition.x > position.x) && (collisionposition.y == position.y)  && direction =="right" ){
			Destroy(collision.gameObject);
			right = false;
		}
		if ((collisionposition.x < position.x) && (collisionposition.y == position.y)  && direction =="left" ){
			Destroy(collision.gameObject);
			left = false;
		}
		if ((collisionposition.y > position.y) && (collisionposition.x == position.x)  && direction =="up" ){
			Destroy(collision.gameObject);
			up = false;
		}
		if ((collisionposition.y < position.y) && (collisionposition.x == position.x)  && direction =="down" ){
			Destroy(collision.gameObject);
			down = false;
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
