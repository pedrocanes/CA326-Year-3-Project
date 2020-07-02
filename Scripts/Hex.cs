using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

	public int x;
	public int y;

    public bool isOddRow;
    private int completed;
	public string status;
	public GameObject[] neighbours;
	//SEPARATE THE HIGHLIGHTING INTO A DIFFERENT FUNCTION

	void Start(){
	
		if (status == "") {
			status = "Free";
		}
	}

	public GameObject[] GetNeighbours() {

        GameObject[] tempNeighbours = new GameObject[6];
        // So if we are at x, y -- the neighbour to our left is at x-1, y
        GameObject left = GameObject.Find("hexTile_" + (x - 1) + ("_") + y);
        tempNeighbours[0] = left;

        // Right neighbour is also easy to find.
        GameObject right = GameObject.Find("hexTile_" + (x + 1) + ("_") + y);
        tempNeighbours[1] = right;

        //isOddRow == true
        //top left x is the same, y + 1
        //top right x + 1, y + 1
        //bottom left x is the same, y - 1
        //bottom right x - 1, y - 1
        if (isOddRow == true)
        {
            GameObject topLeft = GameObject.Find("hexTile_" + (x) + ("_") + (y + 1));
            GameObject topRight = GameObject.Find("hexTile_" + (x + 1) + "_" + (y + 1));
            GameObject bottomLeft = GameObject.Find("hexTile_" + x + "_" + (y - 1));
            GameObject bottomRight = GameObject.Find("hexTile_" + (x + 1) + "_" + (y - 1));
            tempNeighbours[2] = topLeft;
            tempNeighbours[3] = topRight;
            tempNeighbours[4] = bottomLeft;
            tempNeighbours[5] = bottomRight;
        }
        else if (isOddRow == false)
        {
            GameObject topLeft = GameObject.Find("hexTile_" + (x - 1) + "_" + (y + 1));
            GameObject topRight = GameObject.Find("hexTile_" + x + "_" + (y + 1));
            GameObject bottomLeft = GameObject.Find("hexTile_" + (x - 1) + "_" + (y - 1));
            GameObject bottomRight = GameObject.Find("hexTile_" + x + "_" + (y - 1));
            tempNeighbours[2] = topLeft;
            tempNeighbours[3] = topRight;
            tempNeighbours[4] = bottomLeft;
            tempNeighbours[5] = bottomRight;
        }
        int countNotNulls = 0;
        for (int i = 0; i < tempNeighbours.Length; i++)
        {
            if (tempNeighbours[i] != null)
            {
                countNotNulls++;
            }
        }

        GameObject[] neighbours = new GameObject[countNotNulls];
        int notNullarr = 0;
        for (int x = 0; x < tempNeighbours.Length; x++)
        {
            if (tempNeighbours[x] != null)
            {
                neighbours[notNullarr] = tempNeighbours[x];
                notNullarr++;
            }
        }

        return neighbours;
    }

	void Update(){

		//Do nothing
	
	}

	public void showPath (GameObject[] tiles){

		for (int i = 0; i < 6; i++) {
			try{
				string c_status = tiles[i].GetComponent<Hex>().status;
                if (c_status == "Free" && tiles[i] != null)
                {
                    MeshRenderer mr = tiles[i].GetComponentInChildren<MeshRenderer>();
                    mr.material.color = Color.blue;
                    tiles[i].GetComponent<Hex>().status = "Blue";
                }
                else if (c_status == "enemy" && tiles[i] != null) {

                    MeshRenderer mr = tiles[i].GetComponentInChildren<MeshRenderer>();
                    mr.material.color = Color.blue;
                    tiles[i].GetComponent<Hex>().status = "Blue";

                }
			}
				catch {
				//Debug.Log ("Failed to highlight tile: "+i);
			}
		}
	
	}

	public void offPath (GameObject[] tiles){

		for (int i = 0; i < 6; i++) {
			try{
                MeshRenderer mr = tiles[i].GetComponentInChildren<MeshRenderer> ();
				mr.material.color = Color.white;
                if(tiles[i].GetComponent<Hex>().status == "Blue"){
                     tiles[i].GetComponent<Hex>().status = "Free";
                }
			} catch {
				//Debug.Log ("Failed to turn off tile: "+i);
			}
		}

	}

    public void turnOffAllLights()
    {
        GameObject gameObject = GameObject.Find("game");
        GameObject[] playerUnits = gameObject.GetComponent<player>().unitObjects;
        int unitAmount = gameObject.GetComponent<player>().unitAmount;

        for (int i = 0; i < unitAmount; i++)
        {
            try
            {
                unit unit = playerUnits[i].GetComponent<unit>();
                GameObject onTile = GameObject.Find("hexTile_" + unit.x + "_" + unit.y);
                MeshRenderer onTileLight = onTile.GetComponentInChildren<MeshRenderer>();
                onTileLight.material.color = Color.white;

                GameObject[] onTileNeighbours = onTile.GetComponent<Hex>().GetNeighbours();

                onTile.GetComponent<Hex>().offPath(onTileNeighbours);
            }
            catch
            {

                //do nothing

            }
        }

        GameObject enemyGameObject = GameObject.Find("enemyPlayer");
        GameObject[] enemyUnits = enemyGameObject.GetComponent<enemy>().enemyUnits;
        unitAmount = enemyGameObject.GetComponent<enemy>().unitAmount;

        for (int i = 0; i < unitAmount; i++)
        {
            try
            {
                unit unit = enemyUnits[i].GetComponent<unit>();
                GameObject onTile = GameObject.Find("hexTile_" + unit.x + "_" + unit.y);
                MeshRenderer onTileLight = onTile.GetComponentInChildren<MeshRenderer>();
                onTileLight.material.color = Color.white;

                GameObject[] onTileNeighbours = onTile.GetComponent<Hex>().GetNeighbours();

                onTile.GetComponent<Hex>().offPath(onTileNeighbours);
            }
            catch {

                // empty object

            }
        }

    }


}
