using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {
	public Object go;
	public int width;
	public int height;

	void Start()
	{
		for(int i = 0;i<height;i++)
		{
			for(int j = 0;j<width;j++)
			{
				go = Instantiate(go,new Vector3(i, j, 0),Quaternion.identity);
				go.name="Tile("+i+","+j+")";
			}
		}
	}
}
