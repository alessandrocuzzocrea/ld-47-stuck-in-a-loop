﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Player player;
    public Goal goal;

    public float totalTimestamp;
    public float levelCurrentTimestamp;
    public float levelDuration;
    public float levelBeatsCount;
    public int currentBeat;
    public int currentBeatTotal;
    public int loopDuration;

    public static float pixelToSecondsRate;

    // Bar
    public PianoRoll pianoRoll;
    public Bar bar;
    public Vector2 initialBarPosition;

    public Note.NoteType buffered1;
    public Note.NoteType buffered2;
    public Note.NoteType buffered3;
    public Note.NoteType buffered4;

    public bool levelEnded;

    // UI
    public Note.NoteType currentInstrument;

    // Levels
    public float tileSize = 16.0f;
    public GameObject[] levels;
    public int currentLevel;
    public GameObject currentLevelGameObject;

    //Coins
    public int currentLevelCoins;
    public int[] coins;

    // Start is called before the first frame update
    void Start()
    {
        currentLevelGameObject = GameObject.Find("Level");
        if (currentLevelGameObject == null)
        {
            currentLevelGameObject = Instantiate(levels[currentLevel]) as GameObject;
        }

        SetupLevel(currentLevelGameObject.GetComponent<Level>());

        //levelCurrentTimestamp = 0.0f;
        ////levelDuration = 64.0f;
        //levelDuration = 8.0f;
        //pixelToSecondsRate = levelDuration * 4.0f;
        //levelBeatsCount = levelDuration * pixelToSecondsRate / tileSize;
        //currentBeat = 0;
        //currentBeatTotal = 0;
        //loopDuration = 4;

        initialBarPosition = bar.transform.position;

        currentInstrument = buffered1 = buffered2 = buffered3 = buffered4 = Note.NoteType.NotSet;

        // Coins
        coins = new int[levels.Length];
    }

    void SetupLevel(Level l)
    {
        levelCurrentTimestamp = 0.0f;
        //levelDuration = 64.0f;
        levelDuration = l.levelDuration;
        loopDuration = l.loopDuration;
        pixelToSecondsRate = levelDuration * 4.0f;
        levelBeatsCount = levelDuration * pixelToSecondsRate / tileSize;
        currentBeat = 0;
        currentBeatTotal = 0;

        player.GetComponent<RememberMe>().posSaved = l.playerInitialPosition.position;
        player.transform.position = l.playerInitialPosition.position;
        goal.transform.position = l.goalInitialPosition.position;

        //coins
        currentLevelCoins = 0;
    }

    void ChangeLevel(int levelNo)
    {
        Destroy(currentLevelGameObject);
        currentLevelGameObject = null;
        if (currentLevelGameObject == null)
        {
            currentLevelGameObject = Instantiate(levels[currentLevel]) as GameObject;
        }

        ResetMain();
    }

    void ResetMain() 
    {
        levelEnded = false;
        player.Reset();
        pianoRoll.Reset();

        //levelCurrentTimestamp = 0.0f;
        //levelDuration = 8.0f;
        //pixelToSecondsRate = levelDuration * 4.0f;
        //levelBeatsCount = levelDuration * pixelToSecondsRate / tileSize;
        //currentBeat = 0;
        //currentBeatTotal = 0;
        //loopDuration = 4;

        SetupLevel(currentLevelGameObject.GetComponent<Level>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

            if (hit)
            {
                if (hit.collider.tag == "BlockUI")
                {
                    return;
                }

                if (hit.collider.GetComponent<InstrumentButton>())
                {
                    hit.collider.GetComponent<InstrumentButton>().Execute();
                    //currentInstrument = i.noteType;
                }

                if (hit.collider.GetComponent<Note>())
                {
                    Note n = hit.collider.GetComponent<Note>();
                    n.setNoteType(n.noteTypeDefault);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

            if (hit)
            {
                if (hit.collider.GetComponent<Note>())
                {
                    Note n = hit.collider.GetComponent<Note>();
                    n.setNoteType(Note.NoteType.NotSet);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (levelEnded)
        {
            player.Stop();
            currentLevel = (currentLevel + 1) % levels.Length;
            ChangeLevel(currentLevel);
            return;
        }

        // Advance time
        totalTimestamp += Time.deltaTime;
        levelCurrentTimestamp += Time.deltaTime;

        // Handle notes
        if (buffered1 != Note.NoteType.NotSet) HandleNote(buffered1);
        if (buffered2 != Note.NoteType.NotSet) HandleNote(buffered2);
        if (buffered3 != Note.NoteType.NotSet) HandleNote(buffered3);
        if (buffered4 != Note.NoteType.NotSet) HandleNote(buffered4);

        buffered1 = buffered2 = buffered3 = buffered4 = Note.NoteType.NotSet;

        if (levelCurrentTimestamp >= levelDuration)
        {
            levelCurrentTimestamp = 0.0f;
            //player.Reset();
        }

        currentBeat = Convert.ToInt32(levelCurrentTimestamp * pixelToSecondsRate / tileSize) % loopDuration;
        currentBeatTotal = Convert.ToInt32(levelCurrentTimestamp * pixelToSecondsRate / tileSize);
        bar.transform.position = initialBarPosition + new Vector2((levelCurrentTimestamp * pixelToSecondsRate) % (loopDuration * tileSize), 0);

    }

    public void AddCoin()
    {
        currentLevelCoins++;
        coins[currentLevel] = currentLevelCoins;
    }

    private void HandleNote(Note.NoteType note)
    {
        if (note == Note.NoteType.Stop)
        {
            player.Stop();
        }

        if (note == Note.NoteType.Run)
        {
            player.Run();
        }

        if (note == Note.NoteType.Walk)
        {
            player.Walk();
        }

        if (note == Note.NoteType.Jump)
        {
            player.Jump();
        }

        if (note == Note.NoteType.Reverse)
        {
            player.Reverse();
        }
    }

    public void BufferNote(Note n)
    {
        if (buffered1 == Note.NoteType.NotSet)
        {
            buffered1 = n.noteType;
            return;
        }
        if (buffered2 == Note.NoteType.NotSet)
        {
            buffered2 = n.noteType;
            return;
        }
        if (buffered3 == Note.NoteType.NotSet)
        {
            buffered3 = n.noteType;
            return;
        }
        if (buffered4 == Note.NoteType.NotSet)
        {
            buffered4 = n.noteType;
            return;
        }
    }

    public void GoalReached()
    {
        levelEnded = true;
    }
}
