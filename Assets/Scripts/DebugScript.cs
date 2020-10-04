using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public Main main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 0, 50, 20), "Reset"))
        {

        }

        if (GUI.Button(new Rect(10, 30, 50, 20), "Pause"))
        {

        }

        GUI.Label(new Rect(150, 0, 400, 20), "Level ended: " + main.levelEnded);
        GUI.Label(new Rect(150, 10, 400, 20), "Current instrument: " + main.currentInstrument);
        GUI.Label(new Rect(150, 20, 400, 20), "Level: " + main.currentLevel);
        GUI.Label(new Rect(150, 30, 400, 20), "Timestamp: " + main.levelCurrentTimestamp);
        GUI.Label(new Rect(150, 40, 400, 20), "BeatCount: " + main.levelBeatsCount);
        GUI.Label(new Rect(150, 50, 400, 20), "currentBeat: " + main.currentBeat + " / " + main.loopDuration);
        GUI.Label(new Rect(150, 60, 400, 20), "currentBeatTotal: " + main.currentBeatTotal + " / " + main.levelBeatsCount);
        GUI.Label(new Rect(150, 70, 400, 20), "currentLevelCoins: " + main.currentLevelCoins);
    }
}
