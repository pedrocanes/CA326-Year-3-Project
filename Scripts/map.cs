using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {

	public int width;
	public int height;

    int tempWidth;
    int tempHeight;

	public GameObject hexPrefab;
	public GameObject playerCorePrefab;
	public GameObject enemyCorePrefab;
	public GameObject wall;

	//Scale of map in terms of Tiles

	float xOffset = 0.882f;
	float zOffset = 0.764f;
    bool flag = false;
    int boardMaker = 0;

    // Use this for initialization
    void Start () {

        tempWidth = width;
        tempHeight = height;
        for (int y = 0; y <= tempHeight; y++)
        {

            for (int x = 0 - boardMaker; x < tempWidth; x++)
            {

                float xPos = x * xOffset;

                // Odd row?
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }

                GameObject hexGameObject = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);

               
                hexGameObject.name = "hexTile_" + x + "_" + y; //Rename hexagons based on X Y positions

                hexGameObject.GetComponent<Hex>().x = x;
                hexGameObject.GetComponent<Hex>().y = y;


                hexGameObject.transform.SetParent(this.transform); //Child all hexagons to Map
                hexGameObject.isStatic = true;

                //Odd Row?
                if (y % 2 == 1)
                {
                    hexGameObject.GetComponent<Hex>().isOddRow = true;
                }


            }
            if (flag == false && y % 2 != 0)
            {
                tempWidth++;
            }
            else if (flag == false && y % 2 == 0)
            {
                boardMaker++;
            }
            if (flag == true && y % 2 == 0)
            {
                tempWidth--;
            }
            else if (flag == true && y % 2 != 0)
            {
                boardMaker--;
            }
            if (y == (tempHeight - 2) / 2f)
            {
                flag = true;
            }
        }

        //Initialise the cores
        GameObject playerCoreTile = GameObject.Find ("hexTile_" + ("-4_") +("7"));
		Vector3 startPos = playerCoreTile.transform.position;
		startPos.y += .25f;
		GameObject playerCore = (GameObject)Instantiate (playerCorePrefab, startPos, Quaternion.identity);
		playerCoreTile.GetComponent<Hex> ().status = "core";
        playerCore.GetComponent<core>().coreName = "player";
        playerCore.GetComponent<core>().x = -4;
        playerCore.GetComponent<core>().y = 7;

        GameObject enemyCoreTile = GameObject.Find ("hexTile_15" +"_7");
		Vector3 startPosEnemy = enemyCoreTile.transform.position;
		startPosEnemy.y += .25f;
		GameObject enemyCore = (GameObject)Instantiate (enemyCorePrefab, startPosEnemy, Quaternion.identity);
        enemyCoreTile.GetComponent<Hex>().status = "core";
        enemyCore.GetComponent<core>().coreName = "enemy";
        enemyCore.GetComponent<core>().x = 15;
        enemyCore.GetComponent<core>().y = 7;

        //Init the random walls
        // UPDATE THIS TO NOT PLACE ANY WALLS WITHIN 5 X OF THE CORES
        int w;
		int h;
		for (int i = 0; i < 3; i++) {
			w = Random.Range (0, 14);
			h = Random.Range (0, 14);
			GameObject randomTile = GameObject.Find ("hexTile_" + (w) +"_"+(h));
			randomTile.GetComponent<Hex> ().status = "wall";
			Vector3 randomPos = randomTile.transform.position;
			GameObject wallTile = (GameObject) Instantiate (wall, randomPos, Quaternion.identity);
            wallTile.GetComponent<wall>().x = w;
            wallTile.GetComponent<wall>().y = h;
        }
		
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
