﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordButtonScript : MonoBehaviour {

	private SymbolRecordManager srm;

	public PlayButtonScript player;

	// Use this for initialization
	void Start () {
		srm = FindObjectOfType<SymbolRecordManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (srm.IsRecording ()) {
			srm.StopRecording ();
		} else if(!srm.IsRecording() && !srm.IsPlaying()){
			srm.StartRecording ();
		}
	}
}
