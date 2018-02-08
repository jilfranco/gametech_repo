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
		startButton.onClick.AddListener(startButtonClicked);
		startButton.onClick.AddListener(quitButtonClicked);
		startButton.Select();
	}

	private void startButtonClicked()
	{
		SceneManager.LoadScene("GameScene");
	}

	private void quitButtonClicked()
	{
		Application.Quit();
	}
}
