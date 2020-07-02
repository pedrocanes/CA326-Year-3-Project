using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class properAI : MonoBehaviour
{

    private List<double> scores;
    private List<int[]> coordinates;
    private List<List<int[]>> paths;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void doATurn()
    {

        GameObject game = GameObject.Find("game");
        GameObject player = GameObject.Find("enemyPlayer");
        GameObject[] playerUnits = player.GetComponent<enemy>().enemyUnits;

        for (int i = 0; i < playerUnits.Length; i++)
        {

            if (playerUnits[i] != null)
            {
                int unitX = playerUnits[i].GetComponent<unit>().x;
                int unitY = playerUnits[i].GetComponent<unit>().y;
                int unitMobility = playerUnits[i].GetComponent<unit>().energy;
                GameObject tile = GameObject.Find("hexTile_" + unitX + "_" + unitY);
                scores = new List<double>();
                coordinates = new List<int[]>();
                paths = new List<List<int[]>>();
                getBestPath(tile, unitMobility, 0.0, new List<int[]>());
                double maxScore = 9999;
                if (scores.Count > 0)
                {

                    foreach (double item in scores)
                    {
                        maxScore = Math.Min(maxScore, item);
                    }
                    int maxScoreIdx = scores.IndexOf(maxScore);
                    List<int[]> bestPath = paths[maxScoreIdx];
                    int[] finalMove = coordinates[maxScoreIdx];
                    Debug.Log(maxScore + " x: " + finalMove[0] + " y: " + finalMove[1]);
                    foreach (int[] move in bestPath)
                    {
                        //Debug.Log(move[0].ToString() + ", " + move[1].ToString());
                        GameObject bestTile = GameObject.Find("hexTile_" + move[0].ToString() + "_" + move[1].ToString());
                        //Debug.Log("This is the best tile: "+ bestTile);
                        if (bestTile.GetComponent<Hex>().status == "core")
                        {
                            attackCore(playerUnits[i]);
                            return;
                        }
                        else if (bestTile.GetComponent<Hex>().status == "player")
                        {
                            Debug.Log("attacking enemy");
                            String attackUnitName = bestTile.GetComponent<Hex>().currentUnit;
                            aiAttack(GameObject.Find(attackUnitName));
                            playerUnits[i].GetComponent<unit>().energy -= 1;
                            //GameObject.Find("MouseManager").GetComponent<mouseManager>().attackUnit(tile, bestTile);


                        }
                        else
                        {
                            playerUnits[i].GetComponent<unit>().moveAi(playerUnits[i], bestTile);
                            //tile = bestTile;
                        }
                        //Debug.Log("Best path coordinates: " + move[0] + ", " + move[1]);
                    }
                }

                // Debug.Log(maxScore);
                // Debug.Log(maxScoreIdx);
                // Debug.Log(coordinates[maxScoreIdx][0].ToString() + ", " + coordinates[maxScoreIdx][1].ToString());



                // Debug.Log(scores);
                // for (int j = 0; j < scores.Count; j++)
                // {
                //     Debug.Log(scores[j]);
                // }
                // Debug.Log(coordinates);
                //for (int j = 0; j < coordinates.Count; j++)
                //{
                //    Debug.Log("Score: "+ scores[j].ToString() + " At coords: " + coordinates[j][0].ToString() + ", " + coordinates[j][1].ToString());
                //}
            }
        }

        if (game.GetComponent<gameController>().ebusy == false)
        {

            int greens = 0;
            int reds = 0;
            int blues = 0;


            GameObject[] playerUnits2 = player.GetComponent<enemy>().enemyUnits;
            for (int i = 0; i < playerUnits.Length; i++)
            {
                if (playerUnits2[i] != null)
                {

                    if (playerUnits2[i].GetComponent<unit>().timeToProduce == 1)
                    {

                        greens += 1;

                    }

                    if (playerUnits2[i].GetComponent<unit>().timeToProduce == 3)
                    {

                        reds += 1;

                    }

                    if (playerUnits2[i].GetComponent<unit>().timeToProduce == 5)
                    {

                        blues += 1;

                    }

                }
            }

            Debug.Log("Greens: " + greens);
            Debug.Log("Reds: " + reds);
            Debug.Log("Blues: " + blues);

            if (greens < 3)
            {
                GameObject.Find("game").GetComponent<gameController>().enemyUnitCreation(0);
            }

            else if (reds < 2)
            {
                GameObject.Find("game").GetComponent<gameController>().enemyUnitCreation(1);
            }

            else {

                GameObject.Find("game").GetComponent<gameController>().enemyUnitCreation(2);

            }

        }
        

    }

    public void getBestPath(GameObject tile, int movesRemaining, double moveScore, List<int[]> path)
    {

        int myX = tile.GetComponent<Hex>().x;
        int myY = tile.GetComponent<Hex>().y;

        if (movesRemaining == 0)
        {
            scores.Add(moveScore);
            int[] coords = new int[2];
            coords[0] = myX;
            coords[1] = myY;
            coordinates.Add(coords);
            paths.Add(path);
            return;
            //Can't return different types

        }

        GameObject[] moves = new GameObject[6];
        GameObject[] neighbours = tile.GetComponent<Hex>().GetNeighbours();
        GameObject playerCore = GameObject.Find("playerCore(Clone)");

        for (int i = 0; i < neighbours.Length; i++)
        {
            if (neighbours[i].GetComponent<Hex>().status != "Wall")
            {
                float neighX = neighbours[i].GetComponent<Hex>().x;
                float neighY = neighbours[i].GetComponent<Hex>().y;
                double score = getDistance(neighX, neighY, playerCore.GetComponent<core>().x, playerCore.GetComponent<core>().y) / 2;

                GameObject[] humanUnits = GameObject.Find("game").GetComponent<player>().unitObjects;

                for (int j = 0; j < humanUnits.Length && humanUnits[j] != null; j++)
                {
                    int[] pos = GameObject.Find("game").GetComponent<unitObject>().getPosition(humanUnits[j]);
                    GameObject unitTile = GameObject.Find("hexTile_" +pos[0]+ "_" + pos[1]);
                    score = Math.Min(getDistance(neighX, neighY, humanUnits[j].GetComponent<unit>().x, humanUnits[j].GetComponent<unit>().y), score);
                }

                int[] pathCoords = new int[2];
                int[] coords = GameObject.Find("game").GetComponent<unitObject>().getPosition(neighbours[i]);
                pathCoords[0] = coords[0];
                pathCoords[1] = coords[1];
                List<int[]> newPath = new List<int[]>(path);
                newPath.Add(pathCoords);

                if (neighbours[i].GetComponent<Hex>().status == "playerCore")
                {
                    score = -100;
                    getBestPath(neighbours[i], 0, moveScore + score, newPath);
                    return;
                }
                else if (neighbours[i].GetComponent<Hex>().status != "enemy")
                {
                    getBestPath(neighbours[i], movesRemaining - 1, moveScore + score, newPath);
                }

            }
        }


    }

    public double getDistance(float x, float y, float targetX, float targetY)
    {
        return Math.Sqrt(Math.Pow(x - targetX, 2) + Math.Pow(y - targetY, 2));
    }

    public void attackCore(GameObject unit)
    {

        GameObject onTile = GameObject.Find("hexTile_" + unit.GetComponent<unit>().x + "_" + unit.GetComponent<unit>().y);
        GameObject[] enemyUnits = GameObject.Find("enemyPlayer").GetComponent<enemy>().enemyUnits;
        unit.GetComponent<unit>().dead = true;
        unit.GetComponent<unit>().x = 999;
        unit.GetComponent<unit>().y = 999;
        onTile.GetComponent<Hex>().status = "Free";
        onTile.GetComponent<Hex>().currentUnit = null;

        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] == unit)
            {

                enemyUnits[i] = null;

            }
        }

        GameObject.Find("playerCore(Clone)").GetComponent<core>().health -= 1;

        //take off life
        GameObject coreCanvas = GameObject.FindGameObjectWithTag("core");
        Transform playerCoreHealth1 = coreCanvas.transform.Find("playerCoreHealth1");
        Transform playerCoreHealth2 = coreCanvas.transform.Find("playerCoreHealth2");
        Transform playerCoreHealth3 = coreCanvas.transform.Find("playerCoreHealth3");

        if (GameObject.Find("playerCore(Clone)").GetComponent<core>().health == 2)
        {
            playerCoreHealth3.gameObject.SetActive(false);
        }
        if (GameObject.Find("playerCore(Clone)").GetComponent<core>().health == 1)
        {
            playerCoreHealth2.gameObject.SetActive(false);
        }
        if (GameObject.Find("playerCore(Clone)").GetComponent<core>().health == 0)
        {
            playerCoreHealth1.gameObject.SetActive(false);
        }

        if (GameObject.Find("playerCore(Clone)").GetComponent<core>().health == 0)
        {
            GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
            Transform gameOverText = mainCanvas.transform.Find("GameOver/playerWins");
            Transform gameOverPanel = mainCanvas.transform.Find("GameOver");
            Transform preventsClick = mainCanvas.transform.Find("preventsClick");
            Text winText = gameOverText.GetComponent<Text>();
            preventsClick.gameObject.SetActive(true);
            gameOverPanel.gameObject.SetActive(true);
            winText.text = "Player Two Wins";
        }

        MeshRenderer onTileLight = onTile.GetComponentInChildren<MeshRenderer>();
        onTileLight.material.color = Color.white;
        unit.transform.position = new Vector3(-999f, -999f, -999f);
        GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();
        return;

    }

    public void aiAttack(GameObject unit) {

        Debug.Log("Ai attack function ran");

        unit.GetComponent<unit>().unitTile.status = "Free";
        unit.GetComponent<unit>().unitTile.currentUnit = null;
        unit.GetComponent<unit>().dead = true;
        unit.GetComponent<unit>().x = 999;
        unit.GetComponent<unit>().y = 999;
        unit.transform.position = new Vector3(-999f, -999f, -999f);
        GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();

        GameObject[] playerUnits = GameObject.Find("game").GetComponent<player>().unitObjects;

        for (int i = 0; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] == unit) {

                playerUnits[i] = null;

            }
        }

    }


}
