/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: Moves object on horizontal axis
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 20.0f;
    private Rigidbody2D rBody;

    /// <summary>
    /// Moves object to the right with positive speed, used negative number to make target move left 
    /// </summary>
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Vector2.right * speed;
    }
}
