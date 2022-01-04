using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Score : MonoBehaviour
{
	//initialise variables
	public Text final_score;
	int finalScore;
	
    // Start is called before the first frame update
    void Start()
    {
    	//the final score is set in a variable finalScore and displayed to the player 
        finalScore = PlayerPrefs.GetInt("Score");
        final_score.text = finalScore.ToString();
    }
}
