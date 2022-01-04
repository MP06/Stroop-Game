using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
	//initialise variables
	public Text word;
	public int score;
	public float finalScore;
	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;
	string[] words;
	Color[] colors;
	int random_txt;
	int random_color;
	int length;
	int seconds_score;
	Timer time;

	public void Start()
    {
    	//words array contains the strings of the colours
    	words = new string[4] { "Red", "Green", "Blue", "Yellow" };
    	//colors array contains the font colours of each string
    	colors = new Color[4] {Color.red, Color.green, Color.blue, Color.yellow};
    	//length of the above arrays
    	length = words.Length;
    	//get function from timer script
    	time = GetComponent<Timer>(); 

    	//add event listeners to each button (colour options), numbers represent the position in the arrays
    	//and call button_click function on click
    	btn1.onClick.AddListener(() => Button_click(0));
    	btn2.onClick.AddListener(() => Button_click(1));
    	btn3.onClick.AddListener(() => Button_click(2));
    	btn4.onClick.AddListener(() => Button_click(3));  	
    }

    //Randomly generate new word
    public void Random_word()
    {
    	//randomly select a position from both the text and color arrays
    	random_txt = Random.Range(0, length);
		random_color = Random.Range(0, length);
	    
	    //while the generated positions are the same repeat the generation process
	    while (random_txt == random_color) {
		    random_txt = Random.Range(0, length);
		    random_color = Random.Range(0, length);
		}

		//if the generated positions are different adjust the onscreen random word text and color
		if (random_txt != random_color){
	    	word.text = words[random_txt];
	    	word.color = colors[random_color];
	    }
    }

    //get the button clicked value and compare it to the random word colour
    public void Button_click(int btn)
    {
    	//if the correct value/button is selected adjust values
    	if (btn == random_color) {
    		//increase score
    		score++;
    		//add score with current time score
    		score += seconds_score;
    		//call end turn from timer script
    		time.End_Turn();
    	}
    	//if the wrong value/button is selected
    	else if (btn != random_color) {
    		//Set time to 0
    		time.seconds = 0;
    		//call end turn from timer script
    		time.End_Turn();
    	}
    }
	
	//Current time is called each turn so that the time bonus added to score is the remaining time the player had left
    public void Current_Time(float seconds)
    {
    	//update seconds_score 
    	seconds_score = (int)seconds;
    }
}
