using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isWalking;
    public bool isRunning;
    public bool isJumping;

    public int jumpFramesDuration;
    public int jumpFramesHalfPoint;
    public int jumpCurrentFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        jumpFramesDuration = 48;
        jumpFramesHalfPoint = 32;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float speed = isJumping ? 1.0f : 1.0f;
        float walkingPace = Time.deltaTime * Main.pixelToSecondsRate * speed;
        float rayLength = 1f;
        

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, 1 << LayerMask.NameToLayer("Ground"));

        if (hit.collider != null && isJumping == false)
        {
            //Debug.Log("Hitting: " + hit.collider.tag + " Name:" + hit.collider.gameObject.name);
            //if (hit.distance)
            //transform.Translate(Vector2.up * -1);
        } else
        {
            transform.Translate(Vector2.up * -1);
        }

        Vector2 distanceToTranslate = Vector2.zero;

        if (isWalking)
        {
            if (isJumping)
            {
                distanceToTranslate += Vector2.right * walkingPace;
            }
            else
            {
                distanceToTranslate += Vector2.right * walkingPace;
            }
        }
        if (isJumping)
        {
            //    // y = − 0.26x2 + 5.1
            //    float constz = 0.26f * Mathf.Pow(transform.position.x, 2) + 5.1f;
            //    //float y = 

            //    distanceToTranslate.y = constz;
            if (jumpCurrentFrame <= jumpFramesDuration)
            {
                if (jumpCurrentFrame <= jumpFramesHalfPoint)
                {
                    float j = 1.0f;
                    transform.Translate(Vector2.up * j * 2.4f);
                    //transform.Translate(Vector2.up * j * 2.4f);
                    //distanceToTranslate += Vector2.right * walkingPace;
                }
                jumpCurrentFrame++;
            } else
            {
                isJumping = false;
                jumpCurrentFrame = 0;
            }       
        } 
        else 
        {
            jumpCurrentFrame = 0;
        }

        transform.Translate(distanceToTranslate);

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }
    public void Stop()
    {
        isWalking = false;
    }

    public void Run()
    {
        isWalking = true;
    }

    public void Walk()
    {
        isWalking = true;
    }

    public void Jump()
    {
        isJumping = true;
    }
}
