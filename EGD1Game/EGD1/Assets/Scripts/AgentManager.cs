using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour {

    public float mutationRate = 0.0f;
    public int memorySize = 5;

    List<ArrayList> memory = new List<ArrayList>();

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown (KeyCode.Q)) {
            DebugAddRandom ();
        }

        if (Input.GetKeyDown (KeyCode.W)) {
            Play ();
        }

	}

    public void StoreRecording(ArrayList recording) {

        for (int i = 0; i < memory.Count; i++) {
            // Check how close it is
            // if close, modify then return
        }

        // Else this is a new pattern, remove last pattern and add new one
        if (memory.Count + 1 > memorySize) {
            memory.RemoveAt (memory.Count - 1);
        }

        memory.Add(recording);
    }

    void Play() {
        // Add code to decide what to play from memory, chooses randomly

        if (memory.Count == 0) {
            Debug.Log ("I know nothing!");
            return;
        }

        ArrayList pattern = memory [Random.Range (0, memory.Count)];

        // Add code to really play it, now just outputs pattern
        DebugPlay(pattern);
    }

    void DebugPlay(ArrayList pattern) {
        string output = "";

        for (int i = 0; i < pattern.Count; i++) {
            output += ((ArrayList)pattern [i]) [0] + " (" + ((ArrayList)pattern [i])[1].ToString() + ") | ";
        }

        Debug.Log (output);
    }

    void DebugAddRandom() {
        List<string> options = new List<string> ();
        ArrayList pattern = new ArrayList ();

        options.Add ("star");
        options.Add ("heart");
        options.Add ("bell");

        float time = 0;

        for (int i = 0; i < 7; i++) {
            ArrayList note = new ArrayList ();
            note.Add (options [Random.Range (0, options.Count)]);
            note.Add (time);

            pattern.Add (note);

            time += Random.Range (0.0f, 2.0f);
        }

        this.StoreRecording (pattern);
    }
}
