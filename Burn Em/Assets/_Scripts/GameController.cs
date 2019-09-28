using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Define some variables that control spawning my waves of enemies
    [Header("Wave Settings")]
    public GameObject hazard;   // What are we spawning?
    public Vector2 spawnValue;  // Where do we spawn our hazards?
    public int hazardCount;     // How many hazards per wave?
    public float startWait;     // How long until the first wave?
    public float spawnWait;     // How much time between each hazard in a wave?
    public float waveWait;      // How long between each wave of hazard?
    public int lives;
    public GameObject player;
    public GameObject explosionPlayer;

    [Header("UI Options")]
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject restartText;
    public Text livesText;

    // Private variables
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Run a separate function from the rest of the code
        // In it's own thread
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // IEnumerator return type is required for Coroutines
    IEnumerator SpawnWaves()
    {
        

        yield return new WaitForSeconds(startWait); // "Pause". This will "wait" for "startWait" seconds
        while(true) // Now we want to spawn some stuff...
        {
            
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); // Wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait);
        }
    }



    // Updates my score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    // Accepts score values, then calls update score.
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void playerGotHit()
    {
        lives -= 1;
        if(lives <= 0)
        {
            GameObject temp = Instantiate(explosionPlayer, player.transform.position, player.transform.rotation);
            Destroy(temp, 5.0f);
            Destroy(player.gameObject);
            gameOverText.SetActive(true);
             restartText.SetActive(true);
        }

    }
    public void onClickRestartButton()
    {
        SceneManager.LoadScene("Main");
      
    }
   
}
