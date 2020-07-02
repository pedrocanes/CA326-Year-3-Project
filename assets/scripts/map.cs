using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {

	public int width;
	public int height; 

	public GameObject hexPrefab;

	//Scale of map in terms of Tiles

	float xOffset = 0.882f;
	float zOffset = 0.764f;

	// Use this for initialization
	void Start () {

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				float xPos = x * xOffset;

				//Are we on an odd row?
				if(y%2==1){
					xPos += xOffset/2f;
				}
				
				GameObject hexGameObject = (GameObject)Instantiate(hexPrefab, new Vector3(xPos,0,y * zOffset), Quaternion.identity); //Create hexagons in correct positions
				hexGameObject.name = "hexTile_" + x + "_" + y; //Rename hexagons based on X,Y positions
				hexGameObject.GetComponent<Hex>().x = x;
				hexGameObject.GetComponent<Hex>().y = y;


				hexGameObject.transform.SetParent (this.transform); //Child all hexagons to Map
				hexGameObject.isStatic = true;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
