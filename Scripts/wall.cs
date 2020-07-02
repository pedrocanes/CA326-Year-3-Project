using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

	public int x;
	public int y;
	public string status;
	// Use this for initialization
	void Start () {


		GameObject currTile = GameObject.Find ("hexTile_" + (x) + "_" + (y));
		currTile.GetComponent<Hex> ().status = "Wall";
		this.transform.position = currTile.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
