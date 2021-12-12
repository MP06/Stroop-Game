using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float timeRemaining = 3;
    public float ogtimeRemaining = 3;
    public float game_length = 10;
    public Text txt;

    void Update()
    {
    	float temp = ogtimeRemaining;
    	float seconds = ogtimeRemaining;
    	
    	seconds = Mathf.Ceil(timeRemaining % 60);
        timeRemaining -= Time.deltaTime; 
        
        if (seconds >= 0)
        {	
            txt.text = seconds.ToString();        	
        }

        else if (seconds <= 0)
        {        	
        	seconds = temp;
        	game_length--;
        	//Debug.Log(game_length);

        	if (game_length == 0) {
        		SceneManager.LoadScene("End_Game");
        	}
        	else {
        		timeRemaining = temp;
        	}
        }
    }
}
