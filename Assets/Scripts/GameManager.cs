using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // make the global instance of the Game Manager, make it public to get, private to set 
    // (as to not accidentally set it somewhere else like a doofus)
    public static GameManager gameManagerInstance { get; private set; }

    // gameplay variables
    [Header("Gameplay Variables")]
    [SerializeField]
    private float enemyRespawnTime;

    // enemy game manager variables
    public GameObject[] enemyArray;
    public List<GameObject> activeEnemyList;
    public int enemiesKilled = 0;
    public int enemiesMissed = 0;

    // player game manager variables
    private GameObject player;
    public int managerCurrentHealth { get; private set; }
    public int managerMaxHealth { get; private set; }

    private void Awake()
    {
        gameManagerInstance = this;
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        managerMaxHealth = 3;
        managerCurrentHealth = managerMaxHealth;
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        ManagerInitializeEnemies();
    }

    // player functions
    public void ManagerMinusPlayerHealth()
    {
        managerCurrentHealth -= 1;
        if (managerCurrentHealth <= 0)
            ManagerKillPlayer();
    }

    public void ManagerKillPlayer()
    {
        managerCurrentHealth = 0;

        player.GetComponent<PolygonCollider2D>().enabled = false;

        GameObject playerSpaceShip = player.transform.GetChild(1).gameObject; // gets the 2nd child of the player gameObject
        ParticleSystem playerExplosion = player.transform.GetChild(2).GetComponent<ParticleSystem>(); // gets the 3rd child of the player gameObject

        playerSpaceShip.SetActive(false);
        playerExplosion.Play();

        StartCoroutine(ManagerSlowTime(1.25f));
    }

    // enemies functions
    private void ManagerInitializeEnemies()
    {
        activeEnemyList = new List<GameObject>();
        foreach (GameObject enemy in enemyArray)
            activeEnemyList.Add(enemy);
    }

    public void ManagerKillEnemy(GameObject deadEnemy)
    {
        activeEnemyList.Remove(deadEnemy);
        deadEnemy.SetActive(false);
        if (activeEnemyList.Count == 0)
            StartCoroutine(ManagerResetAllEnemies());
    }

    private IEnumerator ManagerResetAllEnemies()
    {
        yield return new WaitForSeconds(enemyRespawnTime);
        foreach (GameObject enemy in enemyArray)
        {
            enemy.GetComponent<EnemyScript>().RespawnEnemy();
            activeEnemyList.Add(enemy);
            enemy.SetActive(true);
        }
    }

    public void ManagerEnemiesKilledCounter()
    {
        enemiesKilled += 1;
        Debug.Log(string.Format("Enemies Killed: {0}", enemiesKilled));
    }

    public void ManagerEnemiesMissedCounter()
    {
        enemiesMissed += 1;
        Debug.Log(string.Format("Enemies Missed: {0}", enemiesMissed));
    }

    // laser functions
    public void ManagerKillLaser(GameObject deadLaser)
    {
        if (deadLaser.CompareTag("Laser"))
            Destroy(deadLaser);
        else
            Debug.LogWarning("You're trying to LASER KILL something that isn't a laser, dummy.", deadLaser);
    }

    // time slow down funtion
    private IEnumerator ManagerSlowTime(float lengthOfSlowdown)
    {
        managerCurrentHealth = -1;
        Image levelEndFade = GameObject.Find("LevelEndFade").GetComponent<Image>();
        Color opaque = new Color(16 / 255.0f, 2 / 255.0f, 21 / 255.0f, 255 / 255.0f);
        float currentTime = 0.0f;
        while (currentTime < lengthOfSlowdown)
        {
            float percent = Mathf.Sqrt(currentTime / lengthOfSlowdown);
            Time.timeScale = Mathf.Lerp(1.0f, 0.0f, percent);
            levelEndFade.color = Color.Lerp(Color.clear, opaque, percent);
            currentTime += Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.0f;
    }

	public IEnumerator DestroyParticleSystem(ParticleSystem s)
	{
		yield return new WaitForSeconds(s.main.duration);
		Destroy(s.gameObject);
	}
}
