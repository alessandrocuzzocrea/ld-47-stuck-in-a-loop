using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstrumentButton : MonoBehaviour
{

    public Note.NoteType noteType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);

        //    if (hit)
        //    {
        //        //if (hit.collider.GetComponent<InstrumentButton>())
        //        //{

        //        //}
        //    }
        //}
    }

    public void Execute()
    {
        if (name == "instrument_buttons_reset")
        {
            SceneManager.LoadScene(0);
        }

        if (name == "instrument_buttons_skip")
        {
            GameObject.Find("Main").GetComponent<Main>().GoalReached();
        }

        if (name == "instrument_buttons_ld_page")
        {

        }

        if (name == "instrument_buttons_twitter")
        {

        }
    }
}
