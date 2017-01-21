using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class TouchSensingScript : MonoBehaviour {

	BoxCollider bc;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		print (other.name);
	}
}
