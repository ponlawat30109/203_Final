using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void UIHandler();
    public event UIHandler OnTimer;
    public event UIHandler OnScore;

    public float timeLeft;
    public int score = 0;

    public GameObject spawnpoint;
    [SerializeField] GameObject ballPref;
    private GameObject playerBall;

    public float drag;
    public float angularDrag;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // playerBall = Instantiate(ballPref, spawnpoint.transform.position, Quaternion.identity);
        SpawnBall();
    }

    void Update()
    {
        Timer();
        OnTimer();
        OnScore();
        BallCheck();
    }

    void Timer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ending");
    }

    void SpawnBall()
    {
        playerBall = Instantiate(ballPref, spawnpoint.transform.position, Quaternion.identity);
        // playerBall.GetComponent<BallController>();
    }

    // void OnCollisionEnter(Collision other)
    // {

    // }

    void BallCheck()
    {
        if (BallController.instance.isDestroy == true)
        {
            // Debug.Log("true");

            StartCoroutine(DelaySpawn());
            // MoveCamera.instance.ResetPos();
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1f);
        // MoveCamera.instance.ResetPos();
        if (BallController.instance.isDestroy == true)
        {
            SpawnBall();
            MoveCamera.instance.ResetPos();
            BallController.instance.isDestroy = false;
        }
    }
}
