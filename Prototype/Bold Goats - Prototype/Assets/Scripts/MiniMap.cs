using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        // Minimap follow player code
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        // Minimap rotation code
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
