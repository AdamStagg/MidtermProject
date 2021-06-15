using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float dist = 5;
    [SerializeField] float scale = 1;
    float initialPos;

    private void Awake()
    {
        initialPos = transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(initialPos - (scale * Mathf.PingPong(Mathf.Sin(Time.time),dist)), transform.position.y, transform.position.z);
    }
}
