using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
	[Header("Timer UI")]
	[SerializeField] private Text timer;
	[SerializeField] private Image timeBar;
	[SerializeField] private Image timeBarBG;

	[Header("Pause Menu UI")]
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject pauseButton;

	[Header("Cauldron UI")]
	[SerializeField] private Text cauldronRedAmount;
	[SerializeField] private Text cauldronBlueAmount;
	[SerializeField] private Text cauldronGreenAmount;

	[Header("Endgame UI")]
	[SerializeField] private GameObject gameOverMenu;
	[SerializeField] private Text finalRedAmount;
	[SerializeField] private Text finalBlueAmount;
	[SerializeField] private Text finalGreenAmount;
	[SerializeField] private Text totalScore;

	private string redAmount, blueAmount, greenAmount;
	
	void Update()
	{
		// fill bar and timer UI
		float roundLength = GameManager.gameManagerInstance.roundLength;
		float uiTimeLeft = GameManager.gameManagerInstance.timeRemaining;

		// call cauldron amounts less like this
		redAmount = GameManager.gameManagerInstance.redCollected.ToString("00");
		blueAmount = GameManager.gameManagerInstance.blueCollected.ToString("00");
		greenAmount = GameManager.gameManagerInstance.greenCollected.ToString("00");
		
		// calculate time for changing bar colors
		timer.text = uiTimeLeft.ToString("00.0");
		timeBar.fillAmount = uiTimeLeft / roundLength;

		// change bar colors
		if (uiTimeLeft < 7)
		{
			timeBar.color = new Color(0.85f,0,0,1);
			timeBarBG.color = new Color(0.5f,0,0,0.45f);
		}

		// cauldron amounts UI
		cauldronRedAmount.text = redAmount;
		cauldronBlueAmount.text = blueAmount;
		cauldronGreenAmount.text = greenAmount;
		
		// endgame
		if (GameManager.gameManagerInstance.gameOver)
		{
			EndGameUI();
		}
	}

	public void PauseGameUI()
	{
		pauseMenu.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void ResumeGameUI()
	{
		pauseMenu.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}

	private void EndGameUI()
	{
		// print everything to popup
		Time.timeScale = 0;
		finalRedAmount.text = redAmount;
		finalBlueAmount.text = blueAmount;
		finalGreenAmount.text = greenAmount;
		totalScore.text = GameManager.gameManagerInstance.totalScore.ToString("000");
		gameOverMenu.SetActive(true);
		
	}

	public void LoadScene(string sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
