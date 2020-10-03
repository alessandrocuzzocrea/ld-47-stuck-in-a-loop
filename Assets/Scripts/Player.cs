using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        

        float rayLength = 1f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, 1 << LayerMask.NameToLayer("Ground"));

        if (hit.collider != null)
        {
            Debug.Log("Hitting: " + hit.collider.tag + " Name:" + hit.collider.gameObject.name);
            //if (hit.distance)
            //transform.Translate(Vector2.up * -1);
        } else
        {
            transform.Translate(Vector2.up * -1);
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }
}
