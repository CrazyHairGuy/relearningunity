using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {

	GameObject grabbedObject;
	float grabbedObjectSize;
	//Quaternion lookRot;
	public float speed = 5.0f;
	public float rotSpeed = 5.0f;
	public Vector3 offset = new Vector3(0, 1, 0);
	Quaternion lookRot;
	//GameObject[] pickUppable;

	/*Quaternion lookRot(Quaternion cameraRot){
	
		return cameraRot.SetLookRotation (Camera.main.transform.position, Vector3.up);

	}*/

	GameObject getMouseHoverObject(float range){
		
		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;
		if (Physics.Linecast (position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		return null;

	}

	void TryGrabbedObject(GameObject grabObject){

		if (grabObject == null || !CanGrab(grabObject))
			return;

		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<MeshRenderer> ().bounds.size.magnitude;
		grabbedObject.GetComponent<Rigidbody> ().isKinematic = true;
		
	}

	bool CanGrab(GameObject candidate){

		return candidate.CompareTag("grab");

	}

	void DropObject(){

		if (grabbedObject == null)
			return;
		if (grabbedObject.GetComponent<Rigidbody> () != null)
			grabbedObject.GetComponent<Rigidbody> ().isKinematic = false;
			grabbedObject.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody>().velocity;
		grabbedObject = null;

	}
	
	// Update is called once per frame
	void Update () {

		//pickUppable = GameObject.FindWithTag ("interactable");

		if (Input.GetKeyDown ("e")) {
			if (grabbedObject == null)
				TryGrabbedObject (getMouseHoverObject (5));
			else
				DropObject ();
		}
		if (grabbedObject != null) {
			//Quaternion lookRot = Quaternion.LookRotation (Camera.main.transform.position, Vector3.up);
			//Quaternion newRotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);
			lookRot.Set(this.transform.rotation[0], Camera.main.transform.rotation[1], this.transform.rotation[2], Camera.main.transform.rotation[3]);
			grabbedObject.transform.rotation = Quaternion.Lerp (grabbedObject.transform.rotation, lookRot, Time.deltaTime * rotSpeed);
			Vector3 newPosition = (gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize) + offset;
			grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, newPosition, Time.deltaTime * speed);
			//grabbedObject.transform.rotation = newRotation;
		}
	}
}
