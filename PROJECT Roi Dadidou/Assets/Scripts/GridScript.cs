using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Column {
	public GameObject[] tile ;
}

public class Grid {
	public Column[] grid;
}

public class GridScript : MonoBehaviour {
	public Object ground;
	public Object wall;
	public int width;
	public int height;
	Grid grid;

	void Start()
	{
		for(int i = 0;i<width;i++)
		{
			for(int j = 0;j<height;j++)
			{
				if (i == 0 || j == 0 || i == width - 1 || j == height - 1){
					wall = Instantiate(wall,new Vector3(i, j, 0),Quaternion.identity);
					wall.name="Tile("+i+","+j+")";
					//grid.grid[i].tile[j].AddComponent(wall);

				}
				else{
					ground = Instantiate(ground,new Vector3(i, j, 0),Quaternion.identity);
					ground.name="Tile("+i+","+j+")";
					//grid.grid[i].tile[j].AddComponent(ground);
				}
			}
		}
	}
}
