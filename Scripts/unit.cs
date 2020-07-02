using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit : MonoBehaviour {

	public Text energyText;
	public Vector3 destination;
    public Hex unitTile;
	public int x;
	public int y;
    public int defaultEnergy;
    public int energy;
    public int timeToProduce;
    public string permission;
    public bool dead;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        try
        {
            unitTile = GameObject.Find("hexTile_" + x + "_" + y).GetComponent<Hex>();
            unitTile.status = permission;
            dead = false;
        }
        catch
        {
            // unit is destroyed
        }

        GameObject gameO = GameObject.Find("game");
        string whosTurn = gameO.GetComponent<gameController>().turn;

        if (whosTurn != permission && dead == false) {
            MeshRenderer mr = unitTile.GetComponentInChildren<MeshRenderer>();
            mr.material.color = Color.white;
            return;
        }

        if (this.energy > 0 && dead == false)
        {
            MeshRenderer mr = unitTile.GetComponentInChildren<MeshRenderer>();
            mr.material.color = Color.green;
            
        }
        if (this.energy == 0 && dead == false) {
            MeshRenderer mr = unitTile.GetComponentInChildren<MeshRenderer>();
            mr.material.color = Color.red;
            
        }
  
    }

    public void moveUnit(GameObject mTile)
    {
        //finds energy canvas  -Pedro
        GameObject canvasObject = GameObject.FindGameObjectWithTag("energy");
        Transform textTr = canvasObject.transform.Find("energyPanel/energyLabel");
        //Transform textPanel = canvasObject.transform.Find("energyPanel");
        Text energyText = textTr.GetComponent<Text>();

        if (this.energy > 0)
        {
            GameObject[] neighbours = unitTile.GetComponent<Hex>().GetNeighbours();

            for (int i = 0; i < neighbours.Length; i++)
            {
                if (mTile == neighbours[i] & mTile.GetComponent<Hex>().status == "Blue")
                {
                    unitTile.GetComponent<Hex>().status = "Free";
                    MeshRenderer mr = unitTile.GetComponentInChildren<MeshRenderer>();
                    mr.material.color = Color.white;
                    unitTile.GetComponent<Hex>().offPath(neighbours);
                    Vector3 destPos = mTile.GetComponent<Hex>().transform.position;
                    this.transform.position = destPos;
                    this.x = mTile.GetComponent<Hex>().x;
                    this.y = mTile.GetComponent<Hex>().y;
                    this.energy -= 1;


                    //change energy label and position  -Pedro
                    energyText.text = "Energy : " + this.energy.ToString();
                    //textTr.transform.position = energyPos;
                    //textPanel.transform.position = energyPos;

                    if (this.energy > 0)
                    {
                        GameObject[] newNeighbours = mTile.GetComponent<Hex>().GetNeighbours();
                        mTile.GetComponent<Hex>().showPath(newNeighbours);
                    }

                    return;
                }
            }
        }

    }

}
