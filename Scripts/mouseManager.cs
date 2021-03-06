using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouseManager : MonoBehaviour
{

    public unit selectedUnit;
    public unit selectedUnitTwo;
    unit prevUnit;
    GameObject[] onTileNeighbours;
    int found;
    int checker;

    bool coreUIshow = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //Check if mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {

            //do this
            return;

        }

        RaycastHit hitInfo;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {

            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

            if (ourHitObject.GetComponent<Hex>() != null)
            {
                MouseOver_Hex(ourHitObject);
            }
            else if (ourHitObject.GetComponent<unit>() != null)
            {

                //We are over the unit
                MouseOver_Unit(ourHitObject);

            }
            else if (ourHitObject.GetComponent<core>() != null)
            {
                MouseOverCore(ourHitObject);

            }

        }
    }

    void MouseOver_Hex(GameObject ourHitObject)
    {

        //whos turn is it?
        GameObject gameO = GameObject.Find("game");
        string whosTurn = gameO.GetComponent<gameController>().turn;


        if (Input.GetMouseButtonDown(0))
        {
            
            //If a unit is selected, then move the unit. Otherwise, perform action with tile
            if (selectedUnit != null)
            {

                if(checkClick(ourHitObject)){
                    // All good
                }
                else
                {
                    return;
                }
                if (selectedUnit.energy > 0)
                {
                    selectedUnit.GetComponent<unit>().moveUnit(ourHitObject);
                    return;

                }

            }
        }
    }


    void MouseOverCore(GameObject ourHitObject)
    {

        if (Input.GetMouseButtonDown(0)) {
            if (selectedUnit != null)
            {
                core hitCore = ourHitObject.GetComponent<core>();
                GameObject hitCoreTile = GameObject.Find("hexTile_" + hitCore.x + "_" + hitCore.y);
                GameObject hitUnitTile = GameObject.Find("hexTile_" + selectedUnit.GetComponent<unit>().x + "_" +selectedUnit.GetComponent<unit>().y);
                GameObject[] neighbours = hitUnitTile.GetComponent<Hex>().GetNeighbours();

               
                for (int i = 0; i < neighbours.Length; i++)
                {
                    if (neighbours[i] == hitCoreTile) {
                        checker = 1;
                    }
                }

                if (checker == 0) {

                    return;

                }

                checker = 0;

                GameObject gameO = GameObject.Find("game");
                string whosTurn = gameO.GetComponent<gameController>().turn;
                Debug.Log(ourHitObject.GetComponent<core>().coreName);
                Debug.Log(whosTurn);
                if (ourHitObject.GetComponent<core>().coreName != whosTurn)
                {
                    ourHitObject.GetComponent<core>().health -= 1;

                    //all this is to turn off the lives on screen
                    GameObject coreCanvas = GameObject.FindGameObjectWithTag("core");
                    Transform playerCoreHealth1 = coreCanvas.transform.Find("playerCoreHealth1");
                    Transform playerCoreHealth2 = coreCanvas.transform.Find("playerCoreHealth2");
                    Transform playerCoreHealth3 = coreCanvas.transform.Find("playerCoreHealth3");

                    Transform enemyCoreHealth1 = coreCanvas.transform.Find("enemyCoreHealth1");
                    Transform enemyCoreHealth2 = coreCanvas.transform.Find("enemyCoreHealth2");
                    Transform enemyCoreHealth3 = coreCanvas.transform.Find("enemyCoreHealth3");

                    if (ourHitObject.GetComponent<core>().health == 2 && whosTurn == "enemy")
                    {
                        playerCoreHealth3.gameObject.SetActive(false);
                    }
                    if (ourHitObject.GetComponent<core>().health == 1 && whosTurn == "enemy")
                    {
                        playerCoreHealth2.gameObject.SetActive(false);
                    }
                    if (ourHitObject.GetComponent<core>().health == 0 && whosTurn == "enemy")
                    {
                        playerCoreHealth1.gameObject.SetActive(false);
                    }

                    if (ourHitObject.GetComponent<core>().health == 2 && whosTurn == "player")
                    {
                        enemyCoreHealth3.gameObject.SetActive(false);
                    }
                    if (ourHitObject.GetComponent<core>().health == 1 && whosTurn == "player")
                    {
                        enemyCoreHealth2.gameObject.SetActive(false);
                    }
                    if (ourHitObject.GetComponent<core>().health == 0 && whosTurn == "player")
                    {
                        enemyCoreHealth1.gameObject.SetActive(false);
                    }


                    //if health == 0, game over, player 1 wins
                    if (ourHitObject.GetComponent<core>().health == 0 && whosTurn == "player")
                    {
                        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
                        Transform gameOverText = mainCanvas.transform.Find("GameOver/playerWins");
                        Transform gameOverPanel = mainCanvas.transform.Find("GameOver");
                        Transform preventsClick = mainCanvas.transform.Find("preventsClick");
                        Text winText = gameOverText.GetComponent<Text>();

                        preventsClick.gameObject.SetActive(true);
                        gameOverPanel.gameObject.SetActive(true);
                        winText.text = "Player 1 wins";
                    }
                    //if health == 0, game over, player 2 wins
                    else if (ourHitObject.GetComponent<core>().health == 0 && whosTurn == "enemy")
                    {
                        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
                        Transform gameOverText = mainCanvas.transform.Find("GameOver/playerWins");
                        Transform gameOverPanel = mainCanvas.transform.Find("GameOver");
                        Transform preventsClick = mainCanvas.transform.Find("preventsClick");
                        Text winText = gameOverText.GetComponent<Text>();
                        preventsClick.gameObject.SetActive(true);
                        gameOverPanel.gameObject.SetActive(true);
                        winText.text = "Player 2 wins";
                    }



                    GameObject unit = selectedUnit.gameObject;

                    if (whosTurn == "player") {

                        GameObject[] units = GameObject.Find("game").GetComponent<player>().unitObjects;
                        for (int i = 0; i < units.Length; i++)
                        {
                            if(units[i] == unit)
                            {
                                GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();
                                GameObject onTile = GameObject.Find("hexTile_" + units[i].GetComponent<unit>().x + "_" + units[i].GetComponent<unit>().y);
                                Debug.Log(onTile);
                                unit.GetComponent<unit>().dead = true;
                                unit.GetComponent<unit>().x = 999;
                                unit.GetComponent<unit>().y = 999;
                                onTile.GetComponent<Hex>().status = "Free";
                                units[i] = null;
                                MeshRenderer onTileLight = onTile.GetComponentInChildren<MeshRenderer>();
                                onTileLight.material.color = Color.white;
                                unit.transform.position = new Vector3(-999f, -999f, -999f);
                            }
                        }

                    }

                    if (whosTurn == "enemy")
                    {

                        GameObject[] units = GameObject.Find("enemyPlayer").GetComponent<enemy>().enemyUnits;
                        for (int i = 0; i < units.Length; i++)
                        {
                            if (units[i] == unit)
                            {
                                GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();
                                GameObject onTile = GameObject.Find("hexTile_" + units[i].GetComponent<unit>().x + "_" + units[i].GetComponent<unit>().y);
                                Debug.Log(onTile);
                                unit.GetComponent<unit>().dead = true;
                                unit.GetComponent<unit>().x = 999;
                                unit.GetComponent<unit>().y = 999;
                                onTile.GetComponent<Hex>().status = "Free";
                                units[i] = null;
                                MeshRenderer onTileLight = onTile.GetComponentInChildren<MeshRenderer>();
                                onTileLight.material.color = Color.white;
                                unit.transform.position = new Vector3(-999f, -999f, -999f);
                            }
                        }

                    }

                    selectedUnit = null;
                    return;


                }
            }
        }

    }
    void MouseOver_Unit(GameObject ourHitObject)
    {

            GameObject gameO = GameObject.Find("game");
            string whosTurn = gameO.GetComponent<gameController>().turn;

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnitTwo = ourHitObject.GetComponent<unit>();
            try
            {
          
                if (selectedUnitTwo.permission != whosTurn)
                {

                    GameObject unitTile = GameObject.Find("hexTile_" + selectedUnit.x + "_" + selectedUnit.y);
                    GameObject attackTile = GameObject.Find("hexTile_" + selectedUnitTwo.x + "_" + selectedUnitTwo.y);
                    attackUnit(unitTile,attackTile);
                    //selectedUnitTwo = null;
                    return;
                    //attack unit

                }
            }
            catch {
                Debug.Log("Something went wrong");
                
            }

            selectedUnit = ourHitObject.GetComponent<unit>();

            if (selectedUnit.permission == whosTurn)
            {
                turnOffEnergy();
                //finds energy canvas  -Pedro
                GameObject canvasObject = GameObject.FindGameObjectWithTag("energy");
                Transform textTr = canvasObject.transform.Find("energyPanel/energyLabel");
                Transform textPanel = canvasObject.transform.Find("energyPanel");
                Text energyText = textTr.GetComponent<Text>();

                textPanel.gameObject.SetActive(true);


                //TURN OFF ALL LIGHTS HERE 
                GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();


                //change energy label and position  -Pedro
                energyText.text = "Energy : " + selectedUnit.energy.ToString();

                if (selectedUnit.energy > 0)
                {

                    GameObject onTile = GameObject.Find("hexTile_" + selectedUnit.x + "_" + selectedUnit.y);
                    onTile.GetComponent<Hex>().showPath(onTile.GetComponent<Hex>().GetNeighbours());

                }
            }

        }

    }


    public void turnOffEnergy()
    {
    
        GameObject canvasObject = GameObject.FindGameObjectWithTag("energy");
        Transform textTr = canvasObject.transform.Find("energyPanel/energyLabel");
        Transform textPanel = canvasObject.transform.Find("energyPanel");
        //textTr.gameObject.SetActive(false);
        textPanel.gameObject.SetActive(false);

    }

    public bool checkClick(GameObject ourHitObject) {

        GameObject ballsTile = GameObject.Find("hexTile_" + selectedUnit.x + "_" + selectedUnit.y);
        if (ourHitObject.GetComponent<Hex>().status == "Blue")
        {
            return true;
        }
        turnOffEnergy();
        selectedUnit = null;
        selectedUnitTwo = null;
        //turnOffMenu();
        GameObject.Find("hexTile_0_0").GetComponent<Hex>().turnOffAllLights();
        return false;

    }

    public void attackUnit(GameObject unitTile, GameObject attackTile) {

        //Try to check if current selected unit permission == permissions. If not, selectedUnitTwo can become hit object. 
        GameObject[] neighbours = unitTile.GetComponent<Hex>().GetNeighbours();
        GameObject gameO = GameObject.Find("game");
        string whosTurn = gameO.GetComponent<gameController>().turn;

        Debug.Log("Stage 1");
        for (int i = 0; i < neighbours.Length; i++)
        {
            Debug.Log("Stage 2");
            Debug.Log(neighbours[i]);
            Debug.Log(attackTile);
            if (neighbours[i] == attackTile) {
               // Debug.Log("Confirmed neighbour");
                if (attackTile.GetComponent<Hex>().status != whosTurn)
                {
                    Debug.Log("Stage 3");
                    //Destroy unit above tile
                    GameObject[] enemyUnits = null;
                    if (whosTurn == "player")
                    {
                        GameObject enemy = GameObject.Find("enemyPlayer");
                        enemyUnits = enemy.GetComponent<enemy>().enemyUnits;
                    }
                    else
                    {
                        GameObject enemy = GameObject.Find("game");
                        enemyUnits = enemy.GetComponent<player>().unitObjects;
                    }
                    Debug.Log("Stage 3.5");
                    for (int j = 0; j < enemyUnits.Length; j++)
                    {
                            Debug.Log("Stage 3.6");

                        try
                        {
                            if (attackTile.GetComponent<Hex>().x == enemyUnits[j].GetComponent<unit>().x)
                            {
                                Debug.Log("Stage 3.7");
                                if (attackTile.GetComponent<Hex>().y == enemyUnits[j].GetComponent<unit>().y)
                                {
                                    Debug.Log("Stage 4");
                                    Destroy(enemyUnits[j]);
                                    attackTile.GetComponent<Hex>().status = "Free";
                                    unitTile.GetComponent<Hex>().showPath(neighbours);
                                    selectedUnit.energy -= 1;
                                    Debug.Log("Stage 5");
                                    return;

                                }
                            }
                        }
                        catch {
                            //do nothing

                        }
                        

                    }

                }

            }
        }

    }

}

