using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpflat : MonoBehaviour {

	private SymbolRecordManager srm;

	private float spinSpeed = 720f;

	private bool animating = false;

	private float totalRotationSoFar = 0f;
	private Vector3 defaultRotation;

	public GameObject other;
	public bool active = false;

	// Use this for initialization
	void Start () {
		srm = FindObjectOfType<SymbolRecordManager> ();
		defaultRotation = transform.localEulerAngles;
	}

	// Update is called once per frame
	void Update () {
		if (animating) {
			animate ();
		}
	}

	void OnTriggerEnter(Collider other){
		Trigger ();
	}

	public void Trigger(){
		if (srm.IsRecording ()) {
			print ("ADDING");
			srm.AddToNewRecording (gameObject.name);
			animating = true;
			active = !active;
			if (other.GetComponent<sharpflat> ().active) {
				other.GetComponent<sharpflat> ().active = false;
			}
		} else if (srm.IsPlaying ()) {
			animating = true;
		}
	}

	public void TouchByAI()
	{
		animating = true;
	}

	void animate(){
		totalRotationSoFar += Time.deltaTime * spinSpeed;
		if (totalRotationSoFar >= 360) {
			totalRotationSoFar = 0;
			transform.localEulerAngles = new Vector3 (defaultRotation.x + totalRotationSoFar, defaultRotation.y, defaultRotation.z);
			animating = false;
		} else {
			transform.localEulerAngles = new Vector3 (defaultRotation.x + totalRotationSoFar, defaultRotation.y, defaultRotation.z);
		}
	}
}
