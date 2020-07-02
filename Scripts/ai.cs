using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ai : MonoBehaviour
{
    int distanceCoreUnit;
    int closeUnitnum;
    public int turnCounter;
    string unitChosen;
    string stat = "free";
    public Hex unitTile;
    public bool dead;
    public string permission;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject mouseMGR = GameObject.Find("MouseManager");
        //mouseMGR.GetComponent<mouseManager>().turnOffEnergy();

        GameObject gameO = GameObject.Find("game");

        //GameObject.Find("enemyCore(Clone)").GetComponent<core>().health
        GameObject player = GameObject.Find("playerCore(Clone)");
        GameObject enemy = GameObject.Find("enemyCore(Clone)");
        //enemy.GetComponent<core>().makeEnemyUnit(ewhatCore);




        if (gameO.GetComponent<gameController>().turn == "enemy")
        {



            distanceCoreUnit = 18;
            closeUnitnum = -1;

            for (int i = 0; i < player.GetComponent<core>().playerUnitsList.Count; i++)
            {

                if (enemy.GetComponent<core>().x - player.GetComponent<core>().playerUnitsList[i].x <= distanceCoreUnit)
                {
                    //find shortest unit to core
                    distanceCoreUnit = enemy.GetComponent<core>().x - player.GetComponent<core>().playerUnitsList[i].x;
                    closeUnitnum = i;
                }

            }

            //unit creation if cooldown is 0
            if (turnCounter <= 0)
            {

                if (turnCounter <= 0 && unitChosen == "blue")
                {
                    enemy.GetComponent<core>().makeEnemyUnit(2);
                    stat = "free";
                    turnCounter = 0;
                }
                else if (turnCounter <= 0 && unitChosen == "red")
                {
                    enemy.GetComponent<core>().makeEnemyUnit(1);
                    stat = "free";
                    turnCounter = 0;
                }
                else if (turnCounter <= 0 && unitChosen == "green")
                {
                    enemy.GetComponent<core>().makeEnemyUnit(0);
                    stat = "free";
                    turnCounter = 0;
                }

                if (distanceCoreUnit > 8 && stat == "free")
                {
                    //unit further away than 8 tiles
                    //spawn blue unit
                    Debug.Log("making blue");
                    unitChosen = "blue";
                    turnCounter = 5; //creation Time
                    stat = "busy";
                }

                else if (distanceCoreUnit <= 8 && distanceCoreUnit > 5 && stat == "free")
                {
                    //unit 8-5 tiles from core
                    //spawn red unit
                    Debug.Log("making red");
                    unitChosen = "red";
                    turnCounter = 3;
                    stat = "busy";
                }

                else if (distanceCoreUnit <= 5 && stat == "free")
                {
                    //unit less than 5 tiles
                    //spawn green
                    Debug.Log("making green");
                    unitChosen = "green";
                    turnCounter = 1;
                    stat = "busy";
                }

            }


            //move all units as far as energy allows
            for (int i = 0; i < enemy.GetComponent<core>().enemyUnitsList.Count; i++)
            {
                for (int j = 0; j < enemy.GetComponent<core>().enemyUnitsList[i].energy; j++)
                {

                    int distanceUnitEnemyCoreX = Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].x - player.GetComponent<core>().x);
                    int distanceUnitEnemyCoreY = Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].y - player.GetComponent<core>().y);


                    if ((distanceUnitEnemyCoreX + distanceUnitEnemyCoreY) < enemy.GetComponent<core>().enemyUnitsList[i].energy) //near enemy core, attack core
                    {
                        //attack core
                    }

                    else //not near enemy core
                    {
                        GameObject destTile = GameObject.Find("hexTile_" + (enemy.GetComponent<core>().enemyUnitsList[i].x - j) + "_" + enemy.GetComponent<core>().enemyUnitsList[i].y);

                        //move function
                        unitTile = GameObject.Find("hexTile_" + enemy.GetComponent<core>().enemyUnitsList[i].x + "_" + enemy.GetComponent<core>().enemyUnitsList[i].y).GetComponent<Hex>();
                        unitTile.GetComponent<Hex>().status = "Free";

                        enemy.GetComponent<core>().enemyUnitsList[i].transform.position = destTile.transform.position;
                        enemy.GetComponent<core>().enemyUnitsList[i].x = destTile.GetComponent<Hex>().x;
                        enemy.GetComponent<core>().enemyUnitsList[i].y = destTile.GetComponent<Hex>().y;
                        enemy.GetComponent<core>().enemyUnitsList[i].energy -= 1;
                    }

                }
            }

            turnCounter = turnCounter - 2;
            gameO.GetComponent<gameController>().nextTurn();

        }
    }
}
       



//
//            if (gameO.GetComponent<gameController>().turn == "enemy")
//        {
//            //Step 1 - unit creation if cooldown is 0
//            //If there are no player units within 8 blocks of unit, spawn blue unit
//            //If there are units 8-5 blocks of the core, spawn red unit
//            //if there are units closer than 5 blocks, spawn green unit
//            if (turnCounter <= 0)
//            {
//
//                distanceCoreUnit = 18;
//                closeUnitnum = -1;
//
//                for (int i = 0; i < player.GetComponent<core>().playerUnitsList.Count; i++)
//                {
//
//                    if (enemy.GetComponent<core>().x - player.GetComponent<core>().playerUnitsList[i].x <= distanceCoreUnit)
//                    {
//                        //find shortest unit to core
//                        distanceCoreUnit = enemy.GetComponent<core>().x - player.GetComponent<core>().playerUnitsList[i].x;
//                        closeUnitnum = i;
//                    }
//
//                }
//                Debug.Log(distanceCoreUnit);
//                if (distanceCoreUnit > 8)
//                {
//                    //unit further away than 8 tiles
//                    //spawn blue unit
//                    Debug.Log("spawning blue");
//                    enemy.GetComponent<core>().makeEnemyUnit(2);
//                    turnCounter = 5; //creation Time
//                }
//
//                else if (distanceCoreUnit <= 8 && distanceCoreUnit > 5)
//                {
//                    //unit 8-5 tiles from core
//                    //spawn red unit
//                    Debug.Log("spawning red");
//                    enemy.GetComponent<core>().makeEnemyUnit(1);
//                    turnCounter = 3;
//                }
//
//                else if (distanceCoreUnit <= 5)
//                {
//                    //unit less than 5 tiles
//                    //spawn green
//                    Debug.Log("spawning green");
//                    enemy.GetComponent<core>().makeEnemyUnit(0);
//                    turnCounter = 1;
//                }
//
//                if(unitChosen == "blue" && turnCounter == 0)
//
//                gameO.GetComponent<gameController>().enemyUnitCreation(999);
//            }
//
//
//
//
//
//
//
//
//            gameO.GetComponent<gameController>().nextTurn();
//
//
//            ////Step 2 - Attack nearby enenmy units
//            //for (int i = 0; i < enemy.GetComponent<core>().enemyUnitsList.Count; i++)
//            //{
//            //
//            //    for (int j = 0; j < player.GetComponent<core>().playerUnitsList.Count; j++)
//            //    {
//            //        unit shortestUnit = null;
//            //        int shortestUnitDist = 50;
//            //        string moveAxis = "null";
//            //
//            //        //finds nearest player unit
//            //        if ((Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].x - player.GetComponent<core>().playerUnitsList[j].x) <= shortestUnitDist) || (Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].y - player.GetComponent<core>().playerUnitsList[j].y) <= shortestUnitDist))
//            //        {
//            //            if ((Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].x - player.GetComponent<core>().playerUnitsList[j].x) <= shortestUnitDist))
//            //            {
//            //                shortestUnitDist = (Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].x - player.GetComponent<core>().playerUnitsList[j].x));
//            //                shortestUnit = player.GetComponent<core>().playerUnitsList[j];
//            //                moveAxis = "x";
//            //            }
//            //
//            //            else if ((Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].y - player.GetComponent<core>().playerUnitsList[j].y) <= shortestUnitDist))
//            //            {
//            //                shortestUnitDist = (Math.Abs(enemy.GetComponent<core>().enemyUnitsList[i].y - player.GetComponent<core>().playerUnitsList[j].y));
//            //                shortestUnit = player.GetComponent<core>().playerUnitsList[j];
//            //                moveAxis = "y";
//            //            }
//            //        }
//            //
//            //        //checks if nearest unit is within energy range and moves to tile before it
//            //        if (shortestUnitDist <= player.GetComponent<core>().playerUnitsList[i].energy && shortestUnit != null)
//            //        {
//            //            if (moveAxis == "x")
//            //            {
//            //                GameObject moveUnitTile = GameObject.Find("hexTile_" + (shortestUnit.x - 1) + "_" + shortestUnit.y);
//            //                enemy.GetComponent<core>().enemyUnitsList[i].GetComponent<unit>().moveUnit(moveUnitTile);
//            //                enemy.GetComponent<core>().enemyUnitsList[i].energy = -shortestUnitDist;
//            //            }
//            //            else if (moveAxis == "y")
//            //            {
//            //                GameObject moveUnitTile = GameObject.Find("hexTile_" + shortestUnit.x + "_" + (shortestUnit.y - 1));
//            //                enemy.GetComponent<core>().enemyUnitsList[i].GetComponent<unit>().moveUnit(moveUnitTile);
//            //                enemy.GetComponent<core>().enemyUnitsList[i].energy = -shortestUnitDist;
//            //            }
//            //        }
//            //
//            //        //attack time
//            //    }
//            //}
//            //
//            //
//            //
//            ////Step 3 - Move any remaining units forward
//            //
//            //
//            //
//            ////Step 4 - Change turn
//        }
//    }
//}
