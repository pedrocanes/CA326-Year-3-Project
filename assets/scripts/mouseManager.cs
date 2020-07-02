using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hitInfo;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(ray, out hitInfo)){

			GameObject ourHitObject = hitInfo.collider.transform.gameObject;
			MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer> ();

			if (Input.GetMouseButtonDown(0)) {

				Debug.Log ("Neighbours of " + ourHitObject.transform.parent.name);
				ourHitObject.transform.parent.GetComponent<Hex> ().GetNeighbours ();
				//Debug.Log(ourHitObject.transform.parent.name);
				//Clicked on hex.
				//Debug.Log(showN);

				if (mr.material.color == Color.white) {
					mr.material.color = Color.red;	
				} else {
					mr.material.color = Color.white;
				}
			}

	}
}
}
