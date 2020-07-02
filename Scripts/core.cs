using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class core : MonoBehaviour {

	public int health;
    public bool busy;
    public GameObject unitPrefab;
    public GameObject pyramidPrefab;
    public int x;
    public int y;
    public string coreName;
    public List<unit>playerUnitsList = new List<unit>();
    public List<unit> enemyUnitsList = new List<unit>();


    // Use this for initialization
    void Start () {

		health = 3;
        //Initialises both cores
		GameObject map = GameObject.Find ("Map");
		int width = map.GetComponent<map> ().width;

	}
	
	// Update is called once per frame
	void Update () {
	}
  
    public void makePlayerUnit(int i)
    {

        GameObject gameO = GameObject.Find("game");
        string whosTurn = gameO.GetComponent<gameController>().turn;

        if (whosTurn == "player")
;        {
            //IF SPAWN TILE NOT TAKEN
            GameObject spawnTile = GameObject.Find("hexTile_" + ("-3_") + ("7"));

            if (spawnTile.GetComponent<Hex>().status == "Free") //Make green unit
            {

                Vector3 spawnPos = spawnTile.transform.position;
                GameObject newUnit = (GameObject)Instantiate(unitPrefab, spawnPos, Quaternion.identity);
                MeshRenderer newUnitMesh = newUnit.GetComponentInChildren<MeshRenderer>();
                player player = GameObject.Find("game").GetComponent<player>();
                unit newUnitStats = newUnit.GetComponent<unit>();
                newUnit.name = "Unit_" + (player.unitAmount + 1);
                newUnitStats.x = -3;
                newUnitStats.y = 7;
                newUnitStats.permission = "player";
                GameObject[] playerUnits = player.unitObjects;
                int unitAmount = player.unitAmount;
                int found = 0;

                for (int j = 0; j < playerUnits.Length; j++)
                {
                    if (playerUnits[j] == null && found == 0)
                    {
                        playerUnits[j] = newUnit;
                        found = 1;

                    }
                }

                player.unitAmount = unitAmount + 1;

                if (i == 0) // Green Unit
                {
                    newUnitStats.energy = 2;
                    newUnitStats.defaultEnergy = 2;
                    newUnitStats.timeToProduce = 1;
                    newUnitMesh.material.color = new Color(172f / 255f, 215f / 255f, 0f / 255f);
                }
                else if (i == 1) // Orange Unit
                {
                    newUnitStats.energy = 3;
                    newUnitStats.defaultEnergy = 3;
                    newUnitStats.timeToProduce = 3;
                    newUnitMesh.material.color = new Color(255 / 255f, 11f / 255f, 0 / 255f);
                }
                else if (i == 2) // Red Unit
                {
                    newUnitStats.energy = 500;
                    newUnitStats.defaultEnergy = 5;
                    newUnitStats.timeToProduce = 5;
                    newUnitMesh.material.color = new Color(36f / 255f, 101f / 255f, 237f / 255f);
                }

                //GameObject.Find("MouseManager").GetComponent<mouseManager>().turnOffMenu();
                playerUnitsList.Add(newUnitStats);
            }
        }
    }

    public void makeEnemyUnit(int i)
    {

        GameObject gameO = GameObject.Find("game");
        string whosTurn = gameO.GetComponent<gameController>().turn;

        if (whosTurn == "enemy")
        {
            //IF SPAWN TILE NOT TAKEN
            GameObject spawnTile = GameObject.Find("hexTile_" + ("14_") + ("7"));

            if (spawnTile.GetComponent<Hex>().status == "Free") //Make green unit
            {

                Vector3 spawnPos = spawnTile.transform.position;
                GameObject newUnit = (GameObject)Instantiate(pyramidPrefab, spawnPos, Quaternion.identity);
                MeshRenderer newUnitMesh = newUnit.GetComponentInChildren<MeshRenderer>();
                enemy enemy = GameObject.Find("enemyPlayer").GetComponent<enemy>();
                unit newUnitStats = newUnit.GetComponent<unit>();
                newUnit.name = "enemyUnit_" + (enemy.unitAmount + 1);
                newUnitStats.x = 14;
                newUnitStats.y = 7;
                newUnitStats.permission = "enemy";
                GameObject[] enemyUnits = enemy.enemyUnits;
                int unitAmount = enemy.unitAmount;
                enemyUnits[unitAmount] = newUnit;
                enemy.unitAmount = unitAmount + 1;

                if (i == 0) // Green Unit
                {
                    newUnitStats.energy = 2;
                    newUnitStats.defaultEnergy = 2;
                    newUnitStats.timeToProduce = 1;
                    newUnitMesh.material.color = new Color(172f / 255f, 215f / 255f, 0f / 255f);
                }
                else if (i == 1) // Orange Unit
                {
                    newUnitStats.energy = 3;
                    newUnitStats.defaultEnergy = 3;
                    newUnitStats.timeToProduce = 2;
                    newUnitMesh.material.color = new Color(255 / 255f, 11f / 255f, 0 / 255f);
                }
                else if (i == 2) // Blue Unit
                {
                    newUnitStats.energy = 5;
                    newUnitStats.defaultEnergy = 5;
                    newUnitStats.timeToProduce = 5;
                    newUnitMesh.material.color = new Color(36f / 255f, 101f / 255f, 237f / 255f);
                }

                enemyUnitsList.Add(newUnitStats);
                //GameObject.Find("MouseManager").GetComponent<mouseManager>().turnOffMenu();
            }
        }
    }


}
