using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holsterone : MonoBehaviour {

     public Vector3 destination;
	public GameObject holster;
	public GameObject hip;
	public GameObject gun;
     //public float speed = 0.1f;
 
     void Start () {
		destination = transform.position;

     }
     
     void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
			{
			transform.position = Vector3.Lerp (transform.position, holster.transform.position, /*speed*/25 * Time.deltaTime);

			gun.SetActive (true);
			gameObject.SetActive (false);
			} 

     }
}
