using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
	//initialise variables
    public float timeRemaining = 3;
    public float ogtimeRemaining = 3;
    public float game_length = 10;
    public Text txt;
    int game_start = 0;
    public float seconds;
    Game g;
    int turn_end = 0;

    void Update()
    {
    	g = GetComponent<Game>();
    	
    	if (game_start == 0){
    	  	g.Random_word();
    	  	game_start = 1;
    	}   	

    	//initialise variables
    	seconds = ogtimeRemaining;

    	//Get the only the seconds from the remaining time
    	seconds = Mathf.Ceil(timeRemaining % 60);
    	g.Current_Time(seconds);
    	
    	//reduce time
        timeRemaining -= Time.deltaTime;

        time();
    }

    public void time() {   

    	if (turn_end == 1) {
    		seconds = -1;
    		turn_end = 0;
    	} 	

    	//if time is greater than or equal to 0 display countdown
        if (seconds >= 0)
        {	
            txt.text = seconds.ToString();        	
        }

        //if time is less than or equal to 0 reset countdown
        else if (seconds <= 0)
        {        	
        	End_Game();
        }
    }

    public void End_Game()
    {
    	//reduce number of turns left in game
    	game_length--;

    	//if no turns left in game end the game
    	if (game_length == 0) {
    		PlayerPrefs.SetInt("Score", g.score);
    		SceneManager.LoadScene("End_Game");
    	}
    	else {
    		timeRemaining = ogtimeRemaining;
    		seconds = ogtimeRemaining;
    		game_start = 0;
    	}
    }

    public void End_Turn()
    {
    	turn_end = 1;
    }
}
