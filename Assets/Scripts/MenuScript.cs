using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button quitButton;


	private void Start()
	{
		Button stBtn = startButton.GetComponent<Button>();
		Button qtBtn = quitButton.GetComponent<Button>();
		stBtn.onClick.AddListener(LoadGameScene);
		qtBtn.onClick.AddListener(QuitGame);
		startButton.Select();
	}

	private void LoadGameScene()
	{
		SceneManager.LoadScene("endlessRunner");
	}

	private void QuitGame()
	{
		Application.Quit();
	}
}
