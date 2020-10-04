using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject uiENDING;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollEnding(string time, int levelSkipped, int coins)
    {
        uiENDING.SetActive(true);
    }    
}
