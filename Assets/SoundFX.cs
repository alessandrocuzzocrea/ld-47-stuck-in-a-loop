using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public float cooldown;
    public float loller;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        loller = Mathf.Max(0.0f, loller - Time.deltaTime);
    }

    public void Play()
    {
        if (loller <= 0.0f)
        {
            audioSource.Play();
            loller = cooldown;
        }
    }
}
