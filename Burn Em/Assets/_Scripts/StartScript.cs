
/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: On start scene only, loads the main scene when player clicks start.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// loads main scene
    /// </summary>
    public void onClickRestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");

    }
}
