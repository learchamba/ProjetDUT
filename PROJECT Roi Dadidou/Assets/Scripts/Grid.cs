using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid{

	private int width = 10;
	System.Int32 Width { get { return this.width; } set { width = value; } }

	private int height = 10;
	System.Int32 Height { get { return this.height; } set { height = value; } }

	private List<Tile> TileTab = new ArrayList<Tile>(); 


	public Grid(){

		for(int i=0;i<height;i++){
			for(int j=0;j<width;j++){
				TileTab.add(new Tile(i,j));
			}
		}
	}
}


