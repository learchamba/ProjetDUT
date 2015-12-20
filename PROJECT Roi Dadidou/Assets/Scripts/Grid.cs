using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public float width = 20.0f;
	public float height = 10.0f;
	public Color color = Color.white;

	void OnDrawGizmos(){
		Vector3 pos = transform.position ;
		Gizmos.color = color ;

		for ( float y = pos.y  ; y < pos.y + height +0.5f ; y += 1) {
			Gizmos.DrawLine(new Vector3(pos.y +0.5f,y + 0.5f,0.0f),
			                new Vector3(width -0.5f,y  + 0.5f,0.0f));
		}

		for ( float x = pos.x ; x < pos.y + width +0.5f ; x += 1) {
			Gizmos.DrawLine(new Vector3(x + 0.5f,pos.x +0.5f ,0.0f),
			                new Vector3(x + 0.5f,height -0.5f ,0.0f));
		}
	}
}
