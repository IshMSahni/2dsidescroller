using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerscore : MonoBehaviour
{
    private float timeleft = 120;
    public int playerScore = 0;
    public GameObject timeLeftui;
    public GameObject playerscoreui;

    // Update is called once per frame
    void Update()
    {

        timeleft -= Time.deltaTime;
        timeLeftui.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeleft);
        playerscoreui.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        //Debug.Log(timeleft);
        if (timeleft < 0.1f)
        {
            SceneManager.LoadScene("123");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        //Debug.Log ("touched the end of the level");
        if (trig.gameObject.name == "endlevel"){
            CountScore();
            
            SceneManager.LoadScene("123");
        }
        if (trig.gameObject.name == "coin")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }
        if (trig.gameObject.name == "breakblock")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeleft * 10);
        Debug.Log("Data says high score is currently" + datamanagement.dataManagement.highscore);
        datamanagement.dataManagement.highscore = playerScore + (int)(timeleft * 10);
        datamanagement.dataManagement.SaveData();
        Debug.Log("Now that it has been updated data's high score is currently" + datamanagement.dataManagement.highscore);
    }
}
