using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector3 movPos;
    public float movAmount = .1f;

    private Input inputActions;

    private void Awake()
    {
        inputActions = new Input();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        float movementInputForward = inputActions.Game.Forward.ReadValue<float>();
        float movementInputBackward = inputActions.Game.Backward.ReadValue<float>();
        float movementInputLeft = inputActions.Game.Left.ReadValue<float>();
        float movementInputRight = inputActions.Game.Right.ReadValue<float>();
        Move();
    }

    void Move()
    {
        // Forward Movement
        if (UnityEngine.Input.GetButton("Forward"))
        {
            movPos = transform.position;
            movPos.z -= movAmount;
            transform.position = movPos;
        }

        // Backwards Movement
        if (UnityEngine.Input.GetButton("Backward"))
        {
            movPos = transform.position;
            movPos.z += movAmount;
            transform.position = movPos;
        }

        // Side to Side Movement
        // Right
        if (UnityEngine.Input.GetButton("Right"))
        {
            movPos = transform.position;
            movPos.x -= movAmount;
            transform.position = movPos;
        }
        else if (UnityEngine.Input.GetButton("Left"))
        {
            movPos = transform.position;
            movPos.x += movAmount;
            transform.position = movPos;
        }
    }
}
