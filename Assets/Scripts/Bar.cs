using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bar collision with: " + collision.gameObject.gameObject.name);
        Note n = collision.gameObject.GetComponent<Note>();
        if (n.noteType != Note.NoteType.NotSet) 
        { 
            main.BufferNote(collision.gameObject.GetComponent<Note>());
        }
    }
}
