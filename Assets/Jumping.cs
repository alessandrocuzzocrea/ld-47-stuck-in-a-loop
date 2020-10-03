using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public int jumpFramesDuration = 16;
    public int currentFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        currentFrame = 0;
    }

    private void FixedUpdate()
    {
        if (currentFrame <= jumpFramesDuration)
        {
            //float j = Time.deltaTime * Main.pixelToSecondsRate;
            float j = 1.0f;
            transform.Translate(Vector2.up * j * 2);
            currentFrame++;
        } else
        {
            enabled = false;
        }
    }
}
