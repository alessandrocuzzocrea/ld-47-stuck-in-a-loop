using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform playerInitialPosition;
    public Transform goalInitialPosition;
    //public float levelCurrentTimestamp;
    public float levelDuration;
    //public float levelBeatsCount;
    //public int currentBeat;
    //public int currentBeatTotal;
    public int loopDuration;
    //public float pixelToSecondsRate;

    // Start is called before the first frame update
    void Awake()
    {
        //pixelToSecondsRate = levelDuration * 4.0f;
        //levelDuration = 8.0f;
        //pixelToSecondsRate = levelDuration * 4.0f;
        //levelBeatsCount = levelDuration * pixelToSecondsRate / tileSize;
        //currentBeat = 0;
        //currentBeatTotal = 0;
        //loopDuration = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
