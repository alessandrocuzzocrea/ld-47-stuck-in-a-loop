using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 0, 50, 20), "Reset"))
        {

        }

        if (GUI.Button(new Rect(10, 30, 50, 20), "Pause"))
        {

        }
    }
}
