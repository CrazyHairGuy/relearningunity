﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironsights : MonoBehaviour {

     public Vector3 destination;
	public GameObject ironsight;
	public GameObject hip;
	public Camera player;
     //public float speed = 0.1f;
 
     void Start () {
		destination = transform.position;
     }
     
     void Update () {
		if (Input.GetKey (KeyCode.Mouse1))
			{
			transform.position = Vector3.Lerp (transform.position, ironsight.transform.position, /*speed*/25 * Time.deltaTime);
			//player.fieldOfView = 45;
			player.fieldOfView = Mathf.Lerp(player.fieldOfView, 45f, 0.5f);
			} 
		else
			{
			transform.position = Vector3.Lerp (transform.position, hip.transform.position, /*speed*/25 * Time.deltaTime);
			//player.fieldOfView = 60;
			player.fieldOfView = Mathf.Lerp(player.fieldOfView, 60f, 0.5f);
			}
     }
}
