﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	//public Collider buttonTrigger;
	public GameObject door1;
	public GameObject door2;
	public GameObject buttonTop;
	public GameObject door1Dest;
	public GameObject door2Dest;
	public GameObject buttonTopDest;
	Vector3 door1T;
	Vector3 door2T;
	Vector3 buttonT;
	public float speed = 5.0f;
	private bool down = false;

	void OnTriggerEnter(Collider collider){

		Debug.Log ("touch");

		down = true;
	
	}

	void OnTriggerExit(Collider collider){

		Debug.Log ("untouch");

		down = false;

	}

	// Use this for initialization
	void Start () {
		door1T = door1.transform.position;
		door2T = door2.transform.position;
		buttonT = buttonTop.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (down) {
			
			door1.transform.position = Vector3.Lerp (door1.transform.position, door1Dest.transform.position, Time.deltaTime * speed);
			door2.transform.position = Vector3.Lerp (door2.transform.position, door2Dest.transform.position, Time.deltaTime * speed);
			buttonTop.transform.position = Vector3.Lerp (buttonTop.transform.position, buttonTopDest.transform.position, Time.deltaTime * speed);

		} else {

			door1.transform.position = Vector3.Lerp (door1.transform.position, door1T, Time.deltaTime * speed);
			door2.transform.position = Vector3.Lerp (door2.transform.position, door2T, Time.deltaTime * speed);
			buttonTop.transform.position = Vector3.Lerp (buttonTop.transform.position, buttonT, Time.deltaTime * speed);

		}
	}
}
