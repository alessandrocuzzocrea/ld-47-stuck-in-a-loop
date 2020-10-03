using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberMe : MonoBehaviour
{
    public Vector2 posSaved;
    // Start is called before the first frame update
    void Start()
    {
        posSaved = transform.position;
    }

    // Update is called once per frame
    public void PleaseRememberMe()
    {
        transform.position = posSaved;
    }
}
