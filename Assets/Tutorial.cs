using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform r = GetComponent<RectTransform>();
        Vector3 pos = r.position;
        pos.y += 1.0f;
        r.position = pos;
    }
}
