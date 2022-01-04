using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Switch script is called on button click
public class Change_scene : MonoBehaviour
{
    public void NextScene()
    {
    	//Change scene to Game scene
    	SceneManager.LoadScene("Game");        
    }
}