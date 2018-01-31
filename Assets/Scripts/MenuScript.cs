using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button dontButton;

    void Start ()
    {
        Button start = startButton.GetComponent<Button>();
        Button dont = dontButton.GetComponent<Button>();
        start.onClick.AddListener(LoadLevel1);
        dont.onClick.AddListener(ExitGame);
        startButton.Select();
    }

    private void LoadLevel1()
    {
        SceneManager.LoadScene("MazeLevel_1");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
