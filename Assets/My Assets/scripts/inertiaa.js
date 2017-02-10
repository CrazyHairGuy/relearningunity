#pragma strict

var speed: float = 15; // speed to follow camera private 
var localPos: Vector3; 
var hand: GameObject;
private var curPos: Vector3;

function Start()
	{
		localPos = transform.localPosition; // save initial local position 
		curPos = transform.position;
	}

function Update()
	{ 
		// targetPos follows instantly the camera: 
		var targetPos = transform.parent.position + localPos; //+ localPos; //localPos; 
		// curPos follows targetPos with some smoothing delay: 
		curPos = Vector3.Lerp(curPos, targetPos, speed * Time.deltaTime * 1); 
		transform.position = curPos; // update the actual weapon rotation 
	}