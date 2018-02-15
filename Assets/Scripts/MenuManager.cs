using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public static MenuManager menuManagerInstance { get; private set; }
	
	[Header("Button Game Objects")]
	[SerializeField] private Button startButton;
	[SerializeField] private Button quitButton;

	void Start()
	{
		startButton.onClick.AddListener(StartButtonClicked);
		quitButton.onClick.AddListener(QuitButtonClicked);
		startButton.Select();
	}

	private void StartButtonClicked()
	{
		SceneManager.LoadScene("GameScene");
	}

	private void QuitButtonClicked()
	{
		Application.Quit();
	}
}
