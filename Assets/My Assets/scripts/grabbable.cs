using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbable : MonoBehaviour {

	// Use this for initialization

	public int count = 0;

	void OnTriggerEnter(Collider collider){

		if(collider.CompareTag("trigger_button") == false)
			count += 1;

	}

	void OnTriggerExit(Collider collider){
		
		if(collider.CompareTag("trigger_button") == false)
			count -= 1;
		
	}

	/*string ToString(){
		return count;
	}*/

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
