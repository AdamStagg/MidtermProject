using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 movPos;
    public float movAmount = .1f;

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            Move();
        }
       
    }

    void Move()
    {
        // Forward Movement
        if (Input.GetKey(KeyCode.W))
        {
            movPos = transform.position;
            movPos.z += movAmount;
            transform.position = movPos;
        }

        // Backwards Movement
        else if (Input.GetKey(KeyCode.S))
        {
            movPos = transform.position;
            movPos.z -= movAmount;
            transform.position = movPos;
        }

        // Side to Side Movement
        // Right
        if (Input.GetKey(KeyCode.D))
        {
            movPos = transform.position;
            movPos.x += movAmount;
            transform.position = movPos;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movPos = transform.position;
            movPos.x -= movAmount;
            transform.position = movPos;
        }
    }
}
