using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameObject[] unitObjects;
    public int unitAmount;

    // Start is called before the first frame update
    void Start()
    {
        unitObjects = new GameObject[50];

    }

    // Update is called once per frame
    void Update()
    {

        unitAmount = 0;
        for (int i = 0; i < unitObjects.Length; i++)
        {
            if(unitObjects[i] != null)
            {
                unitAmount += 1;
            }
        }

    }
}
