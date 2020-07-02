using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    public string turn;
    public Button turnButton;
    public string winner;
    public string pwho;
    public bool pbusy;
    public int pcreationTime;
    public int pwhatCore;
    public string ewho;
    public bool ebusy;
    public int ecreationTime;
    public int ewhatCore;
    // Start is called before the first frame update
    void Start()
    {

        turnButton.GetComponentInChildren<Text>().text = "End Turn";
        turn = "player";
        pbusy = false;
        ebusy = false;
        turnButton.onClick.AddListener(nextTurn);
    }

    // Update is called once per frame
    void Update()

    {
        if(GameObject.Find("enemyCore(Clone)").GetComponent<core>().health <= 0)
        {
            winner = "Player One";
        }

        if (GameObject.Find("playerCore(Clone)").GetComponent<core>().health <= 0)
        {
            winner = "Player Two";
        }

        if (pbusy == true)
        {

            playerUnitCreation(999);
            disablePlayerMenu();
        }
        else {

            enablePlayerMenu();
        }

        if (ebusy == true)
        {

            enemyUnitCreation(999);
            disableEnemyMenu();
        }
        else
        {
            enableEnemyMenu();

        }

        if (turn == "player") {

            disableEnemyMenu();
            GameObject playerSpawnTile = GameObject.Find("hexTile_-3_7");


        }

        if (turn == "enemy")
        {

            disablePlayerMenu();
            GameObject enemySpawnTile = GameObject.Find("hexTile_14_7");
      
        }



    }

    public void nextTurn() {

        GameObject mouseMGR = GameObject.Find("MouseManager");
        mouseMGR.GetComponent<mouseManager>().turnOffEnergy();

        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        Transform turnDisplayer = mainCanvas.transform.Find("turnPanel/turnText");
        Text turnText = turnDisplayer.GetComponent<Text>();

        core playerCore = GameObject.Find("playerCore(Clone)").GetComponent<core>();
        core enemyCore = GameObject.Find("enemyCore(Clone)").GetComponent<core>();

        if (ebusy == true) {

            
            ecreationTime -= 1;

        }

        if (pbusy == true)
        {


            pcreationTime -= 1;

        }


        if (turn == "player") {

            turnText.text = "Turn : Enemy";
            turn = "enemy";
            enableEnemyMenu();
            GameObject enemy = GameObject.Find("enemyPlayer");
            GameObject[] units =  enemy.GetComponent<enemy>().enemyUnits;

            for (int i = 0; i < units.Length; i++)
            {
                if(units[i] != null)
                {
                    units[i].GetComponent<unit>().energy = units[i].GetComponent<unit>().defaultEnergy;
                }
            }

            }
        else
        {
            turnText.text = "Turn : Player";
            turn = "player";
            enablePlayerMenu();
            GameObject player = GameObject.Find("game");
            GameObject[] units = player.GetComponent<player>().unitObjects;

            for (int i = 0; i < units.Length; i++)
            {
                if (units[i] != null)
                {
                    Debug.Log(units[i]);
                    units[i].GetComponent<unit>().energy = units[i].GetComponent<unit>().defaultEnergy;
                }
            }
        }

        GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();



    }

    public void playerUnitCreation(int i) {

        if (pbusy != true) {

            if (turn == "player")
            {
                GameObject spawnTile = GameObject.Find("hexTile_" + ("-3_") + ("7"));
                if (spawnTile.GetComponent<Hex>().status != "Free") {
                    return;
                }
            }
            else
            {
                GameObject spawnTile = GameObject.Find("hexTile_" + ("14_") + ("7"));
                if (spawnTile.GetComponent<Hex>().status != "Free")
                {
                    return;
                }
            }


            if (i == 0){

                pcreationTime = 1;
                pwho = turn;
                pbusy = true;
                pwhatCore = i;

            }
            if ( i == 1){

                pcreationTime = 3;
                pwho = turn;
                pbusy = true;
                pwhatCore = i;

            }
            if (i == 2){

                pcreationTime = 5;
                pwho = turn;
                pbusy = true;
                pwhatCore = i;

            }

        }
            if (pcreationTime <= 0 && turn == pwho) {

                if (pwho == "player") {

                Debug.Log("Creating player unit");
                    GameObject playerCore = GameObject.Find("playerCore(Clone)");
                    playerCore.GetComponent<core>().makePlayerUnit(pwhatCore);
                    pcreationTime = 0;
                    pwho = "nobody";
                    pbusy = false;
                    pwhatCore = 0;

                }


            }

    }

    public void enemyUnitCreation(int i)
    {

        if (ebusy != true)
        {

            if (turn == "player")
            {
                GameObject spawnTile = GameObject.Find("hexTile_" + ("-3_") + ("7"));
                if (spawnTile.GetComponent<Hex>().status != "Free")
                {
                    return;
                }
            }
            else
            {
                GameObject spawnTile = GameObject.Find("hexTile_" + ("14_") + ("7"));
                if (spawnTile.GetComponent<Hex>().status != "Free")
                {
                    return;
                }
            }


            if (i == 0)
            {

                ecreationTime = 1;
                ewho = turn;
                ebusy = true;
                ewhatCore = i;

            }
            if (i == 1)
            {

                ecreationTime = 3;
                ewho = turn;
                ebusy = true;
                ewhatCore = i;

            }
            if (i == 2)
            {

                ecreationTime = 5;
                ewho = turn;
                ebusy = true;
                ewhatCore = i;

            }

        }
        if (ecreationTime <= 0 && turn == ewho)
        {

            if (ewho == "enemy")
            {

                Debug.Log("Creating enemy unit");
                GameObject enemy = GameObject.Find("enemyCore(Clone)");
                enemy.GetComponent<core>().makeEnemyUnit(ewhatCore);
                ecreationTime = 0;
                ewho = "nobody";
                ebusy = false;
                ewhatCore = 0;

            }


        }

    }

    public void enablePlayerMenu() {

        GameObject.Find("punit1").GetComponent<Button>().interactable = true;
        GameObject.Find("punit2").GetComponent<Button>().interactable = true;
        GameObject.Find("punit3").GetComponent<Button>().interactable = true;

    }

    public void disablePlayerMenu()
    {

        GameObject.Find("punit1").GetComponent<Button>().interactable = false;
        GameObject.Find("punit2").GetComponent<Button>().interactable = false;
        GameObject.Find("punit3").GetComponent<Button>().interactable = false;

    }

    public void enableEnemyMenu()
    {

        GameObject.Find("eunit1").GetComponent<Button>().interactable = true;
        GameObject.Find("eunit2").GetComponent<Button>().interactable = true;
        GameObject.Find("eunit3").GetComponent<Button>().interactable = true;

    }

    public void disableEnemyMenu()
    {

        GameObject.Find("eunit1").GetComponent<Button>().interactable = false;
        GameObject.Find("eunit2").GetComponent<Button>().interactable = false;
        GameObject.Find("eunit3").GetComponent<Button>().interactable = false;

    }

}
