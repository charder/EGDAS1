using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour {

	private SymbolRecordManager srm;

	private float spinSpeed = 720f;
	//private float growSpeed = 2;

	private bool animating = false;
	//private bool growing = false;

	//private Vector3 originalScale = new Vector3();
	//private Vector3 maxScale = new Vector3();

	private float totalRotationSoFar = 0f;
	private float defaultRotation;


	// Use this for initialization
	void Start () {
		srm = FindObjectOfType<SymbolRecordManager> ();
		defaultRotation = transform.localEulerAngles.x;
		//originalScale = transform.localScale;
		//maxScale = originalScale * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (animating) {
			animate ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (srm.IsRecording ()) {
			print ("ADDING");
			srm.AddToNewRecording(gameObject.name);
			animating = true;
		}
	}

	void animate(){
		totalRotationSoFar += Time.deltaTime * spinSpeed;
		if (totalRotationSoFar >= 360) {
			totalRotationSoFar = 0;
			transform.localEulerAngles = new Vector3 (defaultRotation + totalRotationSoFar, 0, 0);
			animating = false;
		} else {
			transform.localEulerAngles = new Vector3 (defaultRotation + totalRotationSoFar, 0, 0);
		}
	}
}
