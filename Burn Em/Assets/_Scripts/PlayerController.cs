/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: Moves the player as well as shoot fire balls and play the fireBall audio
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public float speed = 10.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int lives;

    public GameController gameController;
    public GameObject fireBall;
    public Transform fireBallSpawn;
    public float fireRate = 0.5f;

    [Header("Sounds Settings")]
    private AudioSource _fireSounds;


    // Private Variables
    private Rigidbody2D rBody;
    private float counter = 0.0f;
     
    // Start is called before the first frame update
    void Start()
    {

        rBody = GetComponent<Rigidbody2D>();
        _fireSounds = gameController.audioSources[(int)AudioClips.FIREBALL];
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        //check for click and if counter is lower than fire rate
        if (Input.GetButton("Fire1") && counter > fireRate)
        {
            // creates fire ball at indicated location
            Instantiate(fireBall, fireBallSpawn.position, fireBall.transform.rotation);
            counter = 0.0f;
            _fireSounds.Play();
        }
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);

        rBody.velocity = newVelocity * speed;

        // Limits the player's movement 
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, minX, maxX),  
            Mathf.Clamp(rBody.position.y, minY, maxY));  
    }

}
