using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolRecordManager : MonoBehaviour {

	public bool recording = false;
	public bool playing = false;

	public ArrayList newRecording;

	private float timeStartedRecording = 0f;
	private float timeLastHit = 0f;
	private float shutOffInterval = 3f;

	public ArrayList savedRecordings = new ArrayList();

	public bool playingBack = false;

	public NoteButton Bell;
	public NoteButton Heart;
	public NoteButton Diamond;
	public NoteButton Cloud;
	public NoteButton Bolt;
	public NoteButton Spade;
	public NoteButton Star;
	public NoteButton HighBell;

	public sharpflat Sharp;
	public sharpflat Flat;

	private float timeTillNextPlay = 0f;
	private ArrayList recordingPlaying = new ArrayList();
	private int nextNoteIndex = 0;
	private ArrayList nextNote = new ArrayList();
	private float timeStartedPlaying = 0f;

	// Use this for initialization
	void Start () {
		AddPreRecordings ();
	}
	
	// Update is called once per frame
	void Update () {
		if (recording && Time.time > timeLastHit + shutOffInterval) {
			StopRecording ();
		} else if (playing && Time.time >= timeTillNextPlay) {
			PlayNextNote ();
		}
	}

	public bool IsRecording(){
		return recording;
	}

	public bool IsPlaying(){
		return playing;
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
	}

	public void StopRecording(){
		recording = false;
		if (newRecording.Count > 0) {
			for (int i = 0; i < newRecording.Count; i++) {
				ArrayList data = (ArrayList)newRecording [i];
				string shape = (string)data [0];
				float time = (float)data [1];
				Debug.Log (shape + " " + time.ToString ());
			}
			savedRecordings.Add (newRecording);
		} else {
			
		}
	}

	public void PlayNextNote(){
		
		string noteName = (string)nextNote [0];
		Debug.Log ("PLAYING NEXT NOTE: " + noteName);
		if (noteName == "Bell") {
			Bell.Trigger ();
		} else if (noteName == "Heart") {
			Heart.Trigger ();
		} else if (noteName == "Diamond") {
			Diamond.Trigger ();
		} else if (noteName == "Cloud") {
			Cloud.Trigger ();
		} else if (noteName == "Bolt") {
			Bolt.Trigger ();
		} else if (noteName == "Spade") {
			Spade.Trigger ();
		} else if (noteName == "Star") {
			Star.Trigger ();
		} else if (noteName == "HighBell") {
			HighBell.Trigger ();
		} else if (noteName == "Sharp") {
			Sharp.Trigger ();
			Sharp.active = true;
			Flat.active = false;
		} else if (noteName == "Flat") {
			Flat.Trigger ();
			Sharp.active = false;
			Flat.active = true;
		}
		if (nextNoteIndex < recordingPlaying.Count - 1) {
			nextNoteIndex++;
			nextNote = (ArrayList)recordingPlaying [nextNoteIndex];
			timeTillNextPlay = timeStartedPlaying + (float)nextNote [1];
		} else {
			playing = false;
		}
	}

	public void PlayRandom(){
		int playNumber = Random.Range (0, savedRecordings.Count);
		recordingPlaying = (ArrayList)savedRecordings [playNumber];
		playing = true;
		nextNote = (ArrayList)recordingPlaying [0];
		timeTillNextPlay = Time.time + (float)nextNote [1];
		timeStartedPlaying = Time.time;
		nextNoteIndex = 0;
	}

	public void AddPreRecordings(){
		ArrayList final1 = new ArrayList ();
		ArrayList final2 = new ArrayList ();

		ArrayList a1 = new ArrayList ();
		ArrayList a2 = new ArrayList ();
		ArrayList a3 = new ArrayList ();
		ArrayList a4 = new ArrayList ();
		ArrayList a5 = new ArrayList ();
		ArrayList a6 = new ArrayList ();
		ArrayList a7 = new ArrayList ();
		ArrayList a8 = new ArrayList ();
		a1.Add ("Bell");
		a1.Add (1.08f);
		a2.Add ("Heart");
		a2.Add (1.66f);
		a3.Add ("Diamond");
		a3.Add (2.28f);
		a4.Add ("Bell");
		a4.Add (2.84f);
		a5.Add ("Bell");
		a5.Add (3.42f);
		a6.Add ("Heart");
		a6.Add (3.98f);
		a7.Add ("Diamond");
		a7.Add (4.54f);
		a8.Add ("Bell");
		a8.Add (5.15f);
		final1.Add (a1);
		final1.Add (a2);
		final1.Add (a3);
		final1.Add (a4);
		final1.Add (a5);
		final1.Add (a6);
		final1.Add (a7);
		final1.Add (a8);
		savedRecordings.Add (final1);

		ArrayList b1 = new ArrayList ();
		ArrayList b2 = new ArrayList ();
		ArrayList b3 = new ArrayList ();
		ArrayList b4 = new ArrayList ();
		ArrayList b5 = new ArrayList ();
		ArrayList b6 = new ArrayList ();
		ArrayList b7 = new ArrayList ();
		ArrayList b8 = new ArrayList ();
		ArrayList b9 = new ArrayList ();
		ArrayList b10 = new ArrayList ();
		ArrayList b11 = new ArrayList ();
		ArrayList b12 = new ArrayList ();
		b1.Add ("Bell");
		b1.Add (1.62f);
		b2.Add ("Heart");
		b2.Add (1.82f);
		b3.Add ("Bell");
		b3.Add (2f);
		b4.Add ("Spade");
		b4.Add (2.28f);
		b5.Add ("Bell");
		b5.Add (2.54f);
		b6.Add ("Bell");
		b6.Add (2.84f);
		b7.Add ("Bell");
		b7.Add (5.26f);
		b8.Add ("Bell");
		b8.Add (5.68f);
		b9.Add ("Diamond");
		b9.Add (6.1f);
		b10.Add ("Star");
		b10.Add (8.44f);
		b11.Add ("Star");
		b11.Add (8.76f);
		b12.Add ("Bolt");
		b12.Add (9.28f);
		final2.Add (b1);
		final2.Add (b2);
		final2.Add (b3);
		final2.Add (b4);
		final2.Add (b5);
		final2.Add (b6);
		final2.Add (b7);
		final2.Add (b8);
		final2.Add (b9);
		final2.Add (b10);
		final2.Add (b11);
		final2.Add (b12);
		savedRecordings.Add (final2);
	}
}
