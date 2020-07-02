using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

	public int x;
	public int y;
	private int completed;
	public GameObject[] neighbours;

	public GameObject[] GetNeighbours() {

		GameObject map1 = GameObject.Find ("Map");
		map map = map1.GetComponent<map> ();

			GameObject[] neighbours = new GameObject[6];
			if(x-1 > 0){
			GameObject leftNeighbour = GameObject.Find ("hexTile_" + (x - 1) + ("_") + y);
			neighbours [0] = leftNeighbour;
				//Debug.Log ("Neighbor to the left: "+ neighbours [0]);
			}
			//UPDATE BOUNDS HERE AND SO ON
			if (x + 1 < map.width) {
				GameObject rightNeighbour = GameObject.Find ("hexTile_" + (x + 1) + ("_") + y);
				neighbours [1] = rightNeighbour;
			}
			if (y % 2 == 1) {
				if(x-1 > 0){
				GameObject topLeftNeighbour = GameObject.Find ("hexTile_" + (x + 1) + ("_") + (y + 1));
				neighbours [2] = topLeftNeighbour;
				GameObject bottomLeftNeighbour = GameObject.Find ("hexTile_" + (x + 1) + ("_") + (y - 1));
				neighbours [4] = bottomLeftNeighbour;
				}
				if(x+1 < map.width){
				GameObject topRightNeighbour = GameObject.Find ("hexTile_" + (x) + ("_") + (y + 1));
				neighbours [3] = topRightNeighbour;
				GameObject bottomRightNeighbour = GameObject.Find ("hexTile_" + (x) + ("_") + (y - 1));
				neighbours [5] = bottomRightNeighbour;
				}
			} else {
				if(x-1 > 0){
				GameObject topLeftNeighbour = GameObject.Find ("hexTile_" + (x) + ("_") + (y + 1));
				neighbours [2] = topLeftNeighbour;
				GameObject bottomLeftNeighbour = GameObject.Find ("hexTile_" + (x) + ("_") + (y - 1));
				neighbours [4] = bottomLeftNeighbour;
				}
				if(x+1 < map.width){
				GameObject topRightNeighbour = GameObject.Find ("hexTile_" + (x - 1) + ("_") + (y + 1));
				neighbours [3] = topRightNeighbour;
				GameObject bottomRightNeighbour = GameObject.Find ("hexTile_" + (x - 1) + ("_") + (y - 1));
				neighbours [5] = bottomRightNeighbour;			
				}}

			for (int i = 0; i < 6; i++) {
				MeshRenderer mr = neighbours[i].GetComponentInChildren<MeshRenderer> ();
				mr.material.color = Color.blue;
			}
		if (completed == 0) {
			Debug.Log ("Highlighting neighbours.");
			completed = 1;
			return neighbours;
		}

		if (completed == 1) {
			Debug.Log ("De-highlighting neighbours.");
			for (int i = 0; i < 6; i++) {
				MeshRenderer mr = neighbours [i].GetComponentInChildren<MeshRenderer> ();
				mr.material.color = Color.white;
				completed = 0;
			}
			return neighbours;

		}

		return neighbours;	
}
}
