using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	//Instance Variables
	Vector3 targetPosition;
	Vector3 lookAtTarget;
	Quaternion playerRot;
	float rotSpeed = 5;
	float speed = 10;
	bool moving = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Checkes if the player has pressed the left mouse button//
		if (Input.GetMouseButton(0)) {
			setTargetPosition();
		}
		if (moving) {
			Move ();
		}
	}

	void setTargetPosition(){
		//Creates an raycast from where the mouse points through the main camera//
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

						//räknar ut punkten genom att ge rayen, hitpointen och hur långt bort det max får vara.
		if (Physics.Raycast(myRay, out hit, 1000)){
			targetPosition = hit.point;
			lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
				transform.position.y,
				targetPosition.z - transform.position.z);

			//Creates the rotation variable from the new point
			playerRot = Quaternion.LookRotation(lookAtTarget);
				moving = true;
		
	}
			
}

	void Move(){

		transform.rotation = Quaternion.Slerp (transform.rotation, playerRot, rotSpeed * Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);

		float  distance = Vector3.Distance(transform.position, targetPosition);
		if (distance <= 0.1F)
		{
			moving = false;
		}


	}
}
