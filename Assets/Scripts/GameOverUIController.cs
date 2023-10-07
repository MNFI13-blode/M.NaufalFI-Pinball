using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button Mainmenu;
    private void Start()
    {
        Mainmenu.onClick.AddListener(mainmenu);

    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
