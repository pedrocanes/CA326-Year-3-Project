using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitObject : MonoBehaviour
    //POLYMORPHISM 
{
    public int[] unitPos;

    public int[] getPosition(GameObject unit) {

        unitPos = new int[2];

        if (unit.GetComponent<Hex>() != null) {
            unitPos[0] = unit.GetComponent<Hex>().x;
            unitPos[1] = unit.GetComponent<Hex>().y;
            
        }
        else if (unit.GetComponent<unit>() != null) {
            unitPos[0] = unit.GetComponent<unit>().x;
            unitPos[1] = unit.GetComponent<unit>().y;
        }
        else if (unit.GetComponent<wall>() != null)
        {
            unitPos[0] = unit.GetComponent<wall>().x;
            unitPos[1] = unit.GetComponent<wall>().y;
        }
        else if (unit.GetComponent<core>() != null)
        {
            unitPos[0] = unit.GetComponent<core>().x;
            unitPos[1] = unit.GetComponent<core>().y;
        }

        return unitPos;

    }
}
