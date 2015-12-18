using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GridScript : MonoBehaviour {
	public Object ground1;
	public Object ground2;
	public Object ground3;
	public Object wall;
	public int width;
	public int height;
	float aléa;

	void Start()
	{
		for(int i = 0;i<width;i++)
		{
			for(int j = 0;j<height;j++)
			{
				if (i == 0 || j == 0 || i == width - 1 || j == height - 1){

					wall = Instantiate(wall,new Vector3(i, j, 0),Quaternion.identity);
					wall.name="Tile("+i+","+j+")";

				}
				else{
					aléa = Mathf.Round(Random.Range(0,2));
					if (aléa == 0){
						ground1 = Instantiate(ground1,new Vector3(i, j, 0),Quaternion.identity);
						ground1.name="Tile("+i+","+j+")";
					}
					if (aléa == 1){
						ground2 = Instantiate(ground2,new Vector3(i, j, 0),Quaternion.identity);
						ground2.name="Tile("+i+","+j+")";
					}
					if (aléa == 2){
						ground3 = Instantiate(ground3,new Vector3(i, j, 0),Quaternion.identity);
						ground3.name="Tile("+i+","+j+")";
					}
				}
			}
		}
	}
}
