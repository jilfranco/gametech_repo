using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Button strtBtn = startButton.GetComponent<Button>();
        Button qtBtn = quitButton.GetComponent<Button>();
        strtBtn.onClick.AddListener(StartGame);
        qtBtn.onClick.AddListener(QuitGame);
        strtBtn.Select();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
