using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Player player;

    public float levelCurrentTimestamp;
    public float levelDuration;
    public float levelBeatsCount;

    public static float pixelToSecondsRate = 32.0f;

    // Bar
    public Bar bar;
    public Vector2 initialBarPosition;

    public Note.NoteType buffered1;
    public Note.NoteType buffered2;
    public Note.NoteType buffered3;
    public Note.NoteType buffered4;

    // Start is called before the first frame update
    void Start()
    {
        levelCurrentTimestamp = 0.0f;
        //levelDuration = 64.0f;
        levelDuration = 8.0f;
        levelBeatsCount = levelDuration;

        initialBarPosition = bar.transform.position;

        buffered1 = buffered2 = buffered3 = buffered4 = Note.NoteType.NotSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    
        // Advance time
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
            player.GetComponent<RememberMe>().PleaseRememberMe();
        }
        bar.transform.position = initialBarPosition + new Vector2(levelCurrentTimestamp * pixelToSecondsRate, 0);
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
}
