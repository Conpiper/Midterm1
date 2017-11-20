using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft = 420;
    public int Score = 0;
    public GameObject timeLeftUI;
    public GameObject ScoreUI;
	
	// Update is called once per frame
	void Update () 
    {
        timeLeft -= Time.deltaTime;
        //the (int) just casts a float into an int, you can do this with a double as well
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        ScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)Score);
        //has to be less than .1f cuz its a float my G.
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("FirstPrototype");
        }
	}
    void OnTriggerEnter2D (Collider2D trig)
    {
        CountScore();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            SceneManager.LoadScene("SecondPrototype");
        }
        
       
    }
    void CountScore()
    {
        Score = Score + (int)(timeLeft * 10);
        Debug.Log(Score);
    }
}
