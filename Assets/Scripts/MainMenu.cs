using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // function that is assigned to clicking the buttons on the main menu
    public void LoadLevel(int level)
    {
        if (level == 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (level == 100)
        {
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }
}
