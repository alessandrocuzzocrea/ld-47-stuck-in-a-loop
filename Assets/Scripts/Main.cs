using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Player player;

    public float levelCurrentTimestamp;
    public float levelDuration;
    public float levelBeatsCount;

    // Start is called before the first frame update
    void Start()
    {
        levelCurrentTimestamp = 0.0f;
        //levelDuration = 64.0f;
        levelDuration = 2.0f;
        levelBeatsCount = levelDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        levelCurrentTimestamp += Time.deltaTime;
        if (levelCurrentTimestamp >= levelDuration)
        {
            levelCurrentTimestamp = 0.0f;
            player.GetComponent<RememberMe>().PleaseRememberMe();
        }
    }
}
