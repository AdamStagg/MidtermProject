using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestriction : MonoBehaviour
{
    public float RestrictMinAngle = -55f;
    public float RestrictMaxAngle = 70f;

    private void Update()
    {
        Vector3 Rotation = (UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform));

        if (Rotation.x < RestrictMinAngle)
        {
            UnityEditor.TransformUtils.SetInspectorRotation(gameObject.transform, new Vector3(RestrictMinAngle, Rotation.y, Rotation.z));
        }

        if (Rotation.x > RestrictMaxAngle)
        {
            UnityEditor.TransformUtils.SetInspectorRotation(gameObject.transform, new Vector3(RestrictMaxAngle, Rotation.y, Rotation.z));
        }
    }
}
