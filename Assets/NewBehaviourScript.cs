using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	Vector3 ofset;

	public BoxCollider sphere;
	public Transform planetransform;
	public GameObject legru, legr, legl, legul, armr1, arm, arm2, arm2r;
	// Use this for initialization
	void Start () {
		ofset = Camera.main.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = transform.position + ofset;
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
			GetComponent<Rigidbody> ().AddForce(new Vector3(0,15,0),ForceMode.Impulse);
		}
	}
	void onCollisionEnter(Collision col){
		if (col.gameObject.tag == "hole") {
			Destroy (gameObject);
		}
	}
}
