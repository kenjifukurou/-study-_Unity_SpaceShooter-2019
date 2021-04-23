using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    public Text scoreText;
    public int scoreCount;

    public Text gameOverText;
    public Text restartText;

    private bool gameOver;
    private bool restart;

    // Start is called before the first frame update
    void Start()
    {
        hazardCount = 40;
        StartCoroutine(SpawnWave());
        startWait = 2;
        spawnWait = 0.1f;
        waveWait = 3;

        scoreCount = 0;
        UpdateScore();

        gameOverText.text = "";
        restartText.text = "";

        gameOver = false;
        restart = false;
    }

    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scene_My");
            }
        }
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0.0f, 30);
                Quaternion spawnRotation = new Quaternion();
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' to try again!";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScore)
    {
        scoreCount += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreCount;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
