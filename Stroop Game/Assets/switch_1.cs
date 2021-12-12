using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_1 : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Game");
    }
}