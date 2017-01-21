using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolRecordManager : MonoBehaviour {

	public bool recording = false;

	public ArrayList newRecording;

	private float timeStartedRecording = 0f;
	private float timeLastHit = 0f;
	private float shutOffInterval = 3f;

	public ArrayList savedRecordings = new ArrayList();



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (recording && Time.time > timeLastHit + shutOffInterval) {
			StopRecording ();
		}
	}

	public bool IsRecording(){
		return recording;
	}

	public void AddToNewRecording(string shape){
		if (recording) {
			ArrayList data = new ArrayList();
			data.Add (shape);
			data.Add (Time.time - timeStartedRecording);
			newRecording.Add (data);
			timeLastHit = Time.time;
		}
	}

	public void StartRecording(){
		timeStartedRecording = Time.time;
		newRecording = new ArrayList ();
		recording = true;
		timeLastHit = Time.time;
		print ("RECORDING");
	}

	public void StopRecording(){
		recording = false;
		print ("STOPPED RECORDING");
		if (newRecording.Count > 0) {
			for (int i = 0; i < newRecording.Count; i++) {
				ArrayList data = (ArrayList)newRecording [i];
				string shape = (string)data [0];
				float time = (float)data [1];
				Debug.Log (shape + " " + time.ToString ());
			}
			savedRecordings.Add (newRecording);
		} else {
			print ("Nothing");
		}

	}
}
