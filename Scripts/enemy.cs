using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject[] enemyUnits;
    public int unitAmount;

    // Use this for initialization
    void Start () {

        enemyUnits = new GameObject[50];

    }
	
	// Update is called once per frame
	void Update () {

        unitAmount = 0;
        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] != null)
            {
                unitAmount += 1;
            }
        }

    }

}
