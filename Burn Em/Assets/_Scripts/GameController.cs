
/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: spawn ghosts, calculates and records player lives, deals with player death animations,
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Wave Settings")]
    public GameObject hazard;   // What are we spawning?
    public Vector2 spawnValue;  // Where do we spawn our hazards?
    public int hazardCount;     // How many hazards per wave?
    public float startWait;     // How long until the first wave?
    public float spawnWait;     // How much time between each hazard in a wave?
    public float waveWait;      // How long between each wave of hazard?

    [Header("Player Settings")]
    public int lives;
    public GameObject player;
    public GameObject explosionPlayer;

    [Header("Coin Settings")]
    public GameObject coin;
    public int coinCount;

    [Header("Sound Settings")]
    public AudioClips activeAudio;
    public AudioSource[] audioSources;


    [Header("UI Options")]
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject restartText;
    public Text livesText;

    // Private variables
    private int score = 0;

    void Start()
    {

        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnCoins());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(startWait); // pause the program for 'startwait' time
        while (true) 
        {

            for (int i = 0; i < coinCount; i++)
            {
                Vector2 spawnPositionCoin = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
                Instantiate(coin, spawnPositionCoin, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); 
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    // IEnumerator return type is required for Coroutines
    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait); 
        while(true)
        {
            
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); 
            }
            yield return new WaitForSeconds(waveWait);
        }
    }



    /// <summary>
    /// updates score and lives
    /// </summary>
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    // adds score and calls the updateScore method.
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    /// <summary>
    /// take away life and calls update, as well as play death animations and sounds if live hits 0
    /// </summary>
    public void playerGotHit()
    {
        lives -= 1;
        UpdateScore();
        if(lives > 0) {
            AudioSource dragonroar = audioSources[(int)AudioClips.ROAR];
            dragonroar.Play();
        }

        if(lives <= 0)
        {
            AudioSource dragonDeath = audioSources[(int)AudioClips.DRAGONDEATH];
            dragonDeath.Play();
            GameObject temp = Instantiate(explosionPlayer, player.transform.position, player.transform.rotation);
            Destroy(temp, 5.0f);
            Destroy(player.gameObject);
            gameOverText.SetActive(true);
             restartText.SetActive(true);
        }

    }
    /// <summary>
    /// restarts the game on click
    /// </summary>
    public void onClickRestartButton()
    {
        SceneManager.LoadScene("Main");
      
    }
   
}
