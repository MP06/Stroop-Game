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

    Game g;

    void Update()
    {
    	g = GetComponent<Game>();
    	
    	if (game_start == 0){
    	  	g.Random_word();
    	  	game_start = 1;
    	}

    	//initialise variables
    	float seconds = ogtimeRemaining;

    	//Get the only the seconds from the remaining time
    	seconds = Mathf.Ceil(timeRemaining % 60);
    	//reduce time
        timeRemaining -= Time.deltaTime; 
        
        //if time is greater than or equal to 0 display countdown
        if (seconds >= 0)
        {	
            txt.text = seconds.ToString();        	
        }

        //if time is less than or equal to 0 reset countdown
        else if (seconds <= 0)
        {        	
        	//reduce number of turns left in game 
        	game_length--;

        	//if no turns left in game end the game
        	if (game_length == 0) {
        		SceneManager.LoadScene("End_Game");
        	}
        	else {
        		timeRemaining = ogtimeRemaining;
        		seconds = ogtimeRemaining;
        		game_start = 0;
        	}
        }
    }
}
