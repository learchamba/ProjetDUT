using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile{

	private int size = 50;
	System.Int32 Size { get { return this.size; } set { size = value; } }

	private int positionX;
	System.Int32 PositionX { get { return this.positionX; } set { positionX = value; } }

	private int positionY;
	System.Int32 PositionY { get { return this.positionY; } set { positionY = value; } }


	public void Tile( int x ,int y){
		if ( x > 0 )
			PositionX = x;
		else throw new UnityException();

		if ( y > 0 )
			PositionY = y;
		else throw new UnityException();
	}
}
