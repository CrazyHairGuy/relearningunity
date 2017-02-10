using UnityEngine;
using System.Collections;

public class pausemenu : MonoBehaviour {
	public GameObject menu;
	public GameObject pausecam;
	public GameObject player;
	private bool isShowing = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
			pausecam.SetActive (isShowing);
			player.SetActive (!isShowing);
			/*if (isShowing == true) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}*/
		}
	}
}
