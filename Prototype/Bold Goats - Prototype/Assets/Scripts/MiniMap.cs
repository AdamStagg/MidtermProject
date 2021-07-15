using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    private void LateUpdate()
    {
        // Minimap follow player code
        Vector3 newPos = GameManager.Instance.Player.transform.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        // Minimap rotation code
        transform.rotation = Quaternion.Euler(90f, GameManager.Instance.Player.transform.eulerAngles.y, 0f);
        //transform.rotation = Quaternion.Euler(90f, transform.rotation.y, Mathf.Lerp(GameManager.Instance.Player.transform.rotation.y, transform.rotation.z, 1.0f));
    }
}
