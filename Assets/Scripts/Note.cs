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
    public Sprite reverseSprite;

    public enum NoteType
    {
        NotSet,
        Stop,
        Walk,
        Run,
        Jump,
        Reverse,
    }

    public NoteType noteType;
    public NoteType noteTypeDefault;

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

        switch (noteType)
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
            case NoteType.Reverse:
                spriteRenderer.sprite = reverseSprite;
                spriteRenderer.enabled = true;
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
