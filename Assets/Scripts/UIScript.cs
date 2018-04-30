using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
	[SerializeField] private Text timer;
	[SerializeField] private Image timeBar;
	[SerializeField] private Image timeBarBG;
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject pauseButton;

	[SerializeField] private Text redAmount;
	[SerializeField] private Text blueAmount;
	[SerializeField] private Text greenAmount;

	void Update()
	{
		// fill bar and timer UI
		float roundLength = GameManager.gameManagerInstance.roundLength;
		float uiTimeLeft = GameManager.gameManagerInstance.timeRemaining;
		timer.text = uiTimeLeft.ToString("00.0");
		timeBar.fillAmount = uiTimeLeft / roundLength;

		// change bar colors
		if (timeBar.fillAmount < 0.2f)
		{
			timeBar.color = new Color(0.5f,0,0,1);
			timeBarBG.color = new Color(0.7f,0,0,0.65f);
		}


		// cauldron amounts UI
		redAmount.text = GameManager.gameManagerInstance.redCollected.ToString("00");
		blueAmount.text = GameManager.gameManagerInstance.blueCollected.ToString("00");
		greenAmount.text = GameManager.gameManagerInstance.greenCollected.ToString("00");
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("Scene_MainMenu");
	}

	public void LoadGame()
	{
		SceneManager.LoadScene("Scene_Game");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
