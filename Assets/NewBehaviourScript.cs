using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	Vector3 ofset;
	Vector3 upDown;
	Vector3 upDown2;
	Quaternion first;

//	public BoxCollider sphere;
//	public Transform planetransform;
//	public GameObject legru, legr, legl, legul, armr1, arm, arm2, arm2r;
	// Use this for initialization
	int cameraPos;
	void Start () {
		cameraPos = 0;
		ofset = Camera.main.transform.position - transform.position;
		upDown = Vector3.up * 5;
		upDown2 = Vector3.up * 10;
		first = Camera.main.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraPos == 0) {
			Camera.main.transform.rotation = first;
			Camera.main.transform.position = transform.position + ofset;
		}
		else if (cameraPos == 1) {
			Camera.main.transform.rotation = Quaternion.Euler (0, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z);
			Camera.main.transform.position = transform.position + upDown;
			Camera.main.transform.rotation = Quaternion.Euler(90,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z);
		}
		else if (cameraPos == 2) {
			Camera.main.transform.rotation = Quaternion.Euler (0, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z);
			Camera.main.transform.position = transform.position + upDown2;
			Camera.main.transform.rotation = Quaternion.Euler(90,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z);
		}
		if(Input.GetKey (KeyCode.W)){
			GetComponent<Rigidbody> ().AddForce(new Vector3(0,0,10));
		}
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody> ().AddForce(new Vector3(10,0,0));
		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody> ().AddForce(new Vector3(-10,0,0));
		}
		if(Input.GetKey (KeyCode.S)){
			GetComponent<Rigidbody> ().AddForce(new Vector3(0,0,-10));
		}
		if(Input.GetKeyDown (KeyCode.Space)/* && transform.position.y - planetransform.position.y<=1*/){
//			GetComponent<Rigidbody> ().AddForce(new Vector3(0,15,0),ForceMode.Impulse);
			cameraPos++;
			cameraPos = cameraPos % 3;
		}
	}
	void onCollisionEnter(Collision col){
		if (col.gameObject.tag == "hole") {
			Destroy (gameObject);
		}
	}
}
