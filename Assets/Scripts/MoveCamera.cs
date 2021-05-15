using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static MoveCamera instance;
    [SerializeField] Camera _cam;
    Vector3 camPos;
    void Start()
    {
        instance = this;

        camPos = _cam.transform.position;
        Debug.Log(camPos);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _cam.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }

    public void ResetPos()
    {
        _cam.transform.position = camPos;
    }
}
