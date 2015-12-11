using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(0,0);
        if (transform.position.x - player.transform.position.x == 0)
        {
            pos.x = Mathf.Clamp(transform.position.x, 6.6f, 12.4f);
        }
        if (transform.position.y - player.transform.position.y == 0)
        {
            pos.y = Mathf.Clamp(transform.position.y, 3.5f, 5.5f);
        }
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
	}
}
