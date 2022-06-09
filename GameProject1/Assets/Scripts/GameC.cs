using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameC : MonoBehaviour
{


    

    public static GameC instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }



    public void ShowGameOver()
    {
        RestartGame("Scene_1");
    }
    public void Victory()
    {
        RestartGame("Win");
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    

}