using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	//initialise variables
    public float timeRemaining = 3;
    public float ogtimeRemaining = 3;
    public float game_length = 10;
    public Text txt;
    public float seconds;
    bool game_start = true;
    bool turn_end = false;
    Game g;
    
    void Update()
    {
    	//get function from Game script
    	g = GetComponent<Game>();
    	
    	//if start of game generate random word
    	if (game_start){
    		//call random_word function
    	  	g.Random_word();
    	  	//game_start state is now false
    	  	game_start = false;
    	}   	

    	//initialise variables
    	seconds = ogtimeRemaining;

    	//Get the only the seconds from the remaining time
    	seconds = Mathf.Ceil(timeRemaining % 60);
    	//call current time from timer script
    	g.Current_Time(seconds);
    	
    	//reduce time
        timeRemaining -= Time.deltaTime;

        //call time function
        time();
    }

    //time function displays the current seconds remaining and updates 
    public void time() {   

    	//if end of turn adjust values
    	if (turn_end) {
    		seconds = -1;
    		turn_end = false;
    	} 	

    	//if time is greater than or equal to 0 display countdown
        if (seconds >= 0)
        {	
            txt.text = seconds.ToString();        	
        }

        //if time is less than or equal to 0 reset countdown
        else if (seconds < 0)
        {        	
        	//reduce number of turns left in game
    		game_length--;

    		//if no turns left in game end the game
    		if (game_length == 0) {
    			End_Game();
    		}
    		else {
    			//reset variables for next turn
	    		timeRemaining = ogtimeRemaining;
	    		seconds = ogtimeRemaining;
	    		game_start = true;
	    	}
        }
    }

    //end game sets the final score from game and changes end game scene
    public void End_Game()
    {
    	//set new int of game score
    	PlayerPrefs.SetInt("Score", g.score);
    	//change scenes
    	SceneManager.LoadScene("End_Game");
    }

    //end current turn 
    public void End_Turn()
    {
    	//set boolean value
    	turn_end = true;
    }
}
