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

	int score;

    // Update is called once per frame
    public void Random_word()
    {
    	words = new string[4] { "Red", "Green", "Blue", "Yellow" };
    	colors = new Color[4] {Color.red, Color.green, Color.blue, Color.yellow};
    	length = words.Length;

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

    public void Button_click()
    {
    	
    }

    public void Correct()
    {
    	
    }

    public void Score()
    {

    }

}
