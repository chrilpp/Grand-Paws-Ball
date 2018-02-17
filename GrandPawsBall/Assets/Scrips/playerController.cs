using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

	Vector3 mp = new Vector3();
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
			Debug.Log ("Pressed left click.");
			
		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");

		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
	}
}