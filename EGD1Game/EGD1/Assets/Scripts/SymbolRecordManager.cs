using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolRecordManager : MonoBehaviour {

	public bool recording = false;

	public ArrayList newRecording;

	private float timeStartedRecording = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		}
	}

	public void StartRecording(){
		timeStartedRecording = Time.time;
		newRecording = new ArrayList ();
		recording = true;
		print ("RECORDING");
	}

	public void StopRecording(){
		recording = false;
		print ("STOPPED RECORDING");
		for (int i = 0; i < newRecording.Count; i++) {
			ArrayList data = (ArrayList)newRecording [i];
			string shape = (string)data [0];
			float time = (float)data [1];
			Debug.Log (shape + " " + time.ToString ());
		}
	}
}
