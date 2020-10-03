using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite stopSprite;
    public Sprite walkSprite;
    public Sprite runSprite;
    public Sprite jumpSprite;
    public enum NoteType
    {
        NotSet,
        Stop,
        Walk,
        Run,
        Jump,
    }

    public NoteType noteType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNoteType(NoteType nt) 
    {
        noteType = nt;

        switch (nt)
        {
            case NoteType.NotSet:
                spriteRenderer.sprite = null;
                spriteRenderer.enabled = false;
                break;
            case NoteType.Stop:
                spriteRenderer.sprite = stopSprite;
                spriteRenderer.enabled = true;
                break;
            case NoteType.Walk:
                spriteRenderer.sprite = walkSprite;
                spriteRenderer.enabled = true;
                break;
            case NoteType.Run:
                spriteRenderer.sprite = runSprite;
                spriteRenderer.enabled = true;
                break;
            case NoteType.Jump:
                spriteRenderer.sprite = jumpSprite;
                spriteRenderer.enabled = true;
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
