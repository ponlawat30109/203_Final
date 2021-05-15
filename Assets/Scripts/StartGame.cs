using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
            // UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");

        if (Input.GetKey(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

    }
}
