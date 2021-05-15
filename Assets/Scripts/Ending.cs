using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultScore;

    void Start()
    {
        resultScore.text = $"Score\n{GameManager.instance.score}";
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            // Application.Quit();
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");

        if (Input.GetKey(KeyCode.Space))
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");    
    }
}
