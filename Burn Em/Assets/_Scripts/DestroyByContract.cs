/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: Responsible for taking actions when the ghost hits something, and decide what action to take based on tag of
 what hit the ghost. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContract : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    public int scoreValue = 10;
    public GameController gameController;
    public GameObject playerController;
    public float waitExplosion;
    private AudioSource _ghostDeath;



    void Start()
    {
        //gets gameController by tag
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if(gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }

        if(gameController == null)
        {
            Debug.Log("Cannot find Game Controller script on Object");
        }
        _ghostDeath = gameController.audioSources[(int)AudioClips.GHOSTCRY];

    }

    /// <summary>
    /// checks for tag of object that collided then take action
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }

        // self-destruct and create animation as well as audio, and tells the gameController that gamer got hit
        if(other.tag == "Player")
        {

            
            gameController.playerGotHit();
            GameObject tempExplosion = Instantiate (explosion, this.transform.position, this.transform.rotation);
            Destroy(tempExplosion, 5.0f);
            
            Destroy(this.gameObject);
        }
        // self-destruct and create animation as well as audio, and tells the gameController to add score
        if (other.tag == "Fire")
        {
            _ghostDeath.Play();
            gameController.AddScore(scoreValue);
            GameObject tempExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(tempExplosion, 5.0f); //destroy animation after 5 secs to ensure the animation is finished 

            Destroy(this.gameObject);

        }
        

    }
    
}
