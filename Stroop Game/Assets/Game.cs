using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
	public Text word;
	string[] words;
	Color[] colors;
	int random_txt;
	int random_color;
	int length;
	public int score;
	int seconds_score;
	timer time;

	public float finalScore;

	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;

	public void Start()
    {
    	words = new string[4] { "Red", "Green", "Blue", "Yellow" };
    	colors = new Color[4] {Color.red, Color.green, Color.blue, Color.yellow};
    	length = words.Length;
    	time = GetComponent<timer>(); 

    	btn1.onClick.AddListener(() => Button_click(0));
    	btn2.onClick.AddListener(() => Button_click(1));
    	btn3.onClick.AddListener(() => Button_click(2));
    	btn4.onClick.AddListener(() => Button_click(3));  	
    }

    // Update is called once per frame
    public void Random_word()
    {
    	random_txt = Random.Range(0, length);
		random_color = Random.Range(0, length);
	    
	    while (random_txt == random_color) {
		    random_txt = Random.Range(0, length);
		    random_color = Random.Range(0, length);
		}

		if (random_txt != random_color){
	    	word.text = words[random_txt];
	    	word.color = colors[random_color];
	    }
    }

    public void Button_click(int btn)
    {
    	//if correct option
    	if (btn == random_color) {
    		score++;
    		score += seconds_score;
    		time.End_Turn();
    		//Debug.Log(score);
    	}
    	else if (btn != random_color) {
    		time.seconds = 0;
    		time.End_Turn();
    	}
    }

    public void Current_Time(float seconds)
    {
    	seconds_score = (int)seconds;
    }
}
