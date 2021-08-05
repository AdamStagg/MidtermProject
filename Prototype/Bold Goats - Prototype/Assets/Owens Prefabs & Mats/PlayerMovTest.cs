//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MainPlayer : MonoBehaviour
//{
//    Vector3 movPos;
//    public float movAmount = .1f;
//    // Update is called once per frame
//    void Update()
//    {
//        Move();
//    }

//    void Move()
//    {
//        // Forward Movement
//        if (Input.GetKey(KeyCode.W))
//        {
//            movPos = transform.position;
//            movPos.z += movAmount;
//            transform.position = movPos;
//        }

//        // Backwards Movement
//        if (Input.GetKey(KeyCode.S))
//        {
//            movPos = transform.position;
//            movPos.z -= movAmount;
//            transform.position = movPos;
//        }

//        // Side to Side Movement
//        // Right
//        if (Input.GetKey(KeyCode.D))
//        {
//            movPos = transform.position;
//            movPos.x += movAmount;
//            transform.position = movPos;
//        }
//        else if (Input.GetKey(KeyCode.A))
//        {
//            movPos = transform.position;
//            movPos.x -= movAmount;
//            transform.position = movPos;
//        }
//    }
//}
