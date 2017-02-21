using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour {

	GameObject grabbedObject;
	float grabbedObjectSize;
	public Vector3 offset = new Vector3(0, 1, 0);

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

		return candidate.GetComponent<Rigidbody> () != null;

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

		if (Input.GetKeyDown ("e")) {
			if (grabbedObject == null)
				TryGrabbedObject (getMouseHoverObject (5));
			else
				DropObject ();
		}
		if (grabbedObject != null) {
			Vector3 newPosition = (gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize) + offset;
			grabbedObject.transform.position = newPosition;
		}
	}
}
