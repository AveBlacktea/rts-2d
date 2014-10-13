using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	protected bool moving, rotating;
	
	private Vector3 destination;
	private Vector3 hitPoint;
	private Quaternion targetRotation;

	public float moveSpeed, rotateSpeed;

	 void Update () {

		if (Input.GetMouseButtonDown (0)) {
						hitPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						hitPoint.z = transform.position.z;
										
						//transform.position = Vector3.MoveTowards(transform.position, hitPoint, 2 * Time.deltaTime);
				
						float x = hitPoint.x;
						float y = hitPoint.y;
						float z = 0;
						Vector3 destination = new Vector3 (x, y, z);
						StartMove (destination);
				}
	  


		//not sure if base.Update() is soemthing we need, from stormtek.geek.nz/rts_tutorial
		//base.Update();
		if(rotating) TurnToTarget();
		else if(moving) MakeMove();


	}


//	public void OnMouseDown(GameObject hitObject, Vector3 hitPoint) {
//		Debug.Log ("onmousedown");
//		//base.MouseClick(hitObject, hitPoint, controller);
//		//only handle input if owned by a human player and currently selected
//		//if(player && player.human && currentlySelected) {
//		//	if(hitObject.name == "Ground" && hitPoint != ResourceManager.InvalidPosition) {
//				float x = hitPoint.x;
//				float y = hitPoint.y;
//				float z = 0;
//				Vector3 destination = new Vector3(x, y, z);
//				StartMove(destination);
//		//	}
//		//}
//	}

	public void StartMove(Vector3 destination) {
		Debug.Log ("startmove started");
		this.destination = destination;
		//targetRotation = Quaternion.LookRotation (destination - transform.position);
		rotating = true;
		moving = false;
	}


	
	
	private void TurnToTarget() {
		Debug.Log ("turntotarget");
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed);
		Debug.Log ("turntotarget2");
		//sometimes it gets stuck exactly 180 degrees out in the calculation and does nothing, this check fixes that
		Quaternion inverseTargetRotation = new Quaternion(-targetRotation.x, -targetRotation.y, -targetRotation.z, -targetRotation.w);

		if(transform.rotation == targetRotation || transform.rotation == inverseTargetRotation) {
			//rotating = false;
			//moving = true;
			Debug.Log ("turntotarget3");
		}
		//moved these here, but should be in if statement above, having trouble getting rotation to work
		rotating = false;
		moving = true;
	}




	private void MakeMove() {
		transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 3);
		//rigidbody2D.AddForce(destination * 3 * Time.deltaTime);
		Debug.Log ("makemove's transforming");
		if(transform.position == destination) moving = false;
	}
	
}

