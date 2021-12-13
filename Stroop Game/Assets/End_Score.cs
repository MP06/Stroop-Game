using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Score : MonoBehaviour
{
	public int finalScore;
	public Text final_score;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("Score");
        final_score.text = finalScore.ToString();
        //Debug.Log(finalScore);
    }
}
