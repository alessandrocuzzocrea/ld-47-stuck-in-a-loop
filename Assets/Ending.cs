using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public GameObject uiENDING;
    public Text timeText;
    public Text coinsText;
    public Text levelSkippedText;

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
        timeText.text = "time: " + time;
        coinsText.text = "coins: " + coins + "/36";
        levelSkippedText.text = "level skipped: " + levelSkipped + "/12";
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
