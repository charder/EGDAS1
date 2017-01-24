using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour {
	
	private SymbolRecordManager srm;

	public RecordButtonScript recorder;

	// Use this for initialization
	void Start () {
		srm = FindObjectOfType<SymbolRecordManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (srm.IsPlaying ()) {
			
		} else {
			srm.PlayRandom();
		}
	}
}
