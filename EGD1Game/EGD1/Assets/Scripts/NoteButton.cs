﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour {

	public AudioSource AS;

	public AudioClip FlatNote;
    public AudioClip BaseNote;
	public AudioClip SharpNote;

	private SymbolRecordManager srm;

	private float spinSpeed = 720f;

	private bool animating = false;

	private float totalRotationSoFar = 0f;
	private Vector3 defaultRotation;

	private sharpflat sharp;
	private sharpflat flat;

	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
		srm = FindObjectOfType<SymbolRecordManager> ();
		defaultRotation = transform.localEulerAngles;
		sharp = GameObject.Find ("Sharp").GetComponent<sharpflat>();
		flat = GameObject.Find("Flat").GetComponent<sharpflat>();
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
			srm.AddToNewRecording(gameObject.name);
			animating = true;
			PlayNote ();
		}
		else if (srm.IsPlaying()) {
			animating = true;
			PlayNote ();
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

	public void PlayNote(){
		AudioClip theOne = BaseNote;
		if (flat.active) {
			theOne = FlatNote;
			flat.active = false;
		} else if (sharp.active) {
			theOne = SharpNote;
			sharp.active = false;
		}
		AS.clip = theOne;
		AS.Play ();
	}
}
