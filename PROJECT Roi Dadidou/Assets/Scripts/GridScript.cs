using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {
	public Object ground;
	public Object wall;
	public int width;
	public int height;

	void Start()
	{
		for(int i = 0;i<height;i++)
		{
			for(int j = 0;j<width;j++)
			{
				if (i == 0 || j == 0 || i == width - 1 || j == height - 1){
					wall = Instantiate(wall,new Vector3(i, j, 0),Quaternion.identity);
					wall.name="Tile("+i+","+j+")";
				}
				else{
					ground = Instantiate(ground,new Vector3(i, j, 0),Quaternion.identity);
					ground.name="Tile("+i+","+j+")";
				}
			}
		}
	}
}
