using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button Play;
    public Button Exit;
    private void Start()
    {
        Play.onClick.AddListener(playgame);
        Exit.onClick.AddListener(exitgame);
    }
    private void playgame()
    {
        SceneManager.LoadScene("Start_Game");
    }
    private void exitgame()
    {
        Application.Quit();
    }
}
