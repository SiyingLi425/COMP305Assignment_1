/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: Moves and resets the background picture to achieve scrolling effect
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    public float verticalSpeed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;

   
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// Moves the forest right continuously
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(verticalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the forest to the resetPosition
    /// </summary>
    void Reset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    /// <summary>
    /// checks if the forest's location has reached resetPoint, if yes, resets it at the resetPosition
    /// 
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
