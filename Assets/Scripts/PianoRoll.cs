using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoRoll : MonoBehaviour
{
    //public GameObject notePrefab;
    public Note[] notes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        foreach (Note n in notes)
        {
            //Transform noteTransform = transform.GetChild(i);
            //if (transform.GetComponent<Note>())
            //{
                //Note n = transform.GetComponent<Note>();
                n.setNoteType(Note.NoteType.NotSet);
            //}
        }
    }
}
