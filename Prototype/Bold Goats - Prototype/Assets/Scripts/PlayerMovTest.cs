using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovTest : MonoBehaviour
{
    Vector3 movpos;
    public float movamount = .1f;

    // update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // forward movement
        if (Input.GetKey(KeyCode.W))
        {
            movpos = transform.position;
            movpos.z -= movamount;
            transform.position = movpos;
        }

        // backwards movement
        if (Input.GetKey(KeyCode.S))
        {
            movpos = transform.position;
            movpos.z += movamount;
            transform.position = movpos;
        }

        // side to side movement
        // right
        if (Input.GetKey(KeyCode.D))
        {
            movpos = transform.position;
            movpos.x -= movamount;
            transform.position = movpos;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movpos = transform.position;
            movpos.x += movamount;
            transform.position = movpos;
        }
    }
}
