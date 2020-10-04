using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Main main;

    public bool isWalking;
    public bool isRunning;
    public bool isJumping;
    public bool isReverse;

    public int jumpFramesDuration;
    public int jumpFramesHalfPoint;
    public int jumpCurrentFrame = 0;

    public Vector2 horizontalRayOffset;
    public float horizontalRayLength;
    public float verticalRayLength;

    //public AudioSource jumpSound;

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


        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, rayLength, 1 << LayerMask.NameToLayer("Ground"));
        RaycastHit2D hitHorizontal = Physics2D.Raycast((Vector2)transform.position + horizontalRayOffset, isReverse ? Vector2.left : Vector2.right, horizontalRayLength, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Ground"));
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, verticalRayLength, 1 << LayerMask.NameToLayer("Ceiling"));
        RaycastHit2D hitDown2 = Physics2D.Raycast((Vector2)transform.position + Vector2.up * 48.0f, Vector2.up, rayLength, 1 << LayerMask.NameToLayer("Death"));

        if (hitUp.collider != null)
        {
            //Debug.Log("Ceiling");
        }

        if (hitDown2.collider != null)
        {
            Debug.Log("Death");
            Reset();
            main.PlayDeadSFX();
        }

        bool isHittingCeiling = hitUp.collider != null;

        if (hitHorizontal.collider != null)
        {
            isReverse = !isReverse;
            transform.localScale = isReverse ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            horizontalRayOffset.x *= -1;
        }


        if (hitDown.collider != null && isJumping == false)
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
            distanceToTranslate += Vector2.right * walkingPace * (isReverse ? -1 : 1);
            
        }
        if (isJumping && !isHittingCeiling)
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
            isJumping = false;
        }

        transform.Translate(distanceToTranslate);

        //Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        //Debug.DrawRay(transform.position + (Vector3) horizontalRayOffset, (isReverse ? Vector2.left : Vector2.right) * horizontalRayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.up * verticalRayLength, Color.green);
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
        //jumpSound.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collision with: " + collision.gameObject.gameObject.name);
        //main.BufferNote(collision.gameObject.GetComponent<Note>());
        if (collision.gameObject.GetComponent<Goal>() != null)
        {
            main.GoalReached();
        }

        if (collision.gameObject.GetComponent<Coin>() != null)
        {

            Destroy(collision.gameObject);
            main.AddCoin();
        }
    }

    public void Reset()
    {
        GetComponent<RememberMe>().PleaseRememberMe();
        isRunning = isWalking = isReverse = isJumping = false;
        horizontalRayOffset.x = Mathf.Abs(horizontalRayOffset.x);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Reverse()
    {
        isReverse = !isReverse;
        transform.localScale = isReverse ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        horizontalRayOffset.x *= -1;
    }
}
