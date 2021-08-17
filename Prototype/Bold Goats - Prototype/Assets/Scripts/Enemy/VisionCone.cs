using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

[RequireComponent(typeof(EnemyVision))]
public class VisionCone : MonoBehaviour
{

    public float meshResolution;

    public LayerMask mask;

    EnemyVision enemyVision;

    public MeshFilter viewMeshFilter;
    private Mesh viewMesh;

    private void Start()
    {
        enemyVision = GetComponent<EnemyVision>();

        viewMesh = new Mesh();
        viewMesh.name = "Vision Cone";
        viewMeshFilter.mesh = viewMesh;

    }

    private void LateUpdate()
    {
        DrawVisionCone();
    }

    public void DrawVisionCone()
    {
        int stepCount = Mathf.RoundToInt(enemyVision.maxSightAngle * meshResolution);
        float stepDegrees = enemyVision.maxSightAngle / stepCount;

        List<Vector3> viewPoints = new List<Vector3>();

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - enemyVision.maxSightAngle / 2 + stepDegrees * i;

            Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * enemyVision.visionLength, Color.red);

            ViewCastInfo viewCast = ViewCast(angle);

            viewPoints.Add(viewCast.point);


        }


        int vertexNumber = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexNumber];
        int[] tris = new int[(vertexNumber - 2) * 3];

        vertices[0] = Vector3.zero;

        
        for (int i = 0; i < vertexNumber - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexNumber - 2)
            {
                tris[i * 3] = 0;
                tris[i * 3 + 1] = i + 1;
                tris[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = tris;
        viewMesh.RecalculateNormals();


    }
        public Vector3 DirFromAngle(float angle, bool isGlobal)
        {
            if (!isGlobal)
            {
                angle += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        }

    ViewCastInfo ViewCast(float angle)
    {
        Vector3 direction = DirFromAngle(angle, true);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, enemyVision.visionLength, mask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, angle);
        } else
        {
            return new ViewCastInfo(false, transform.position + direction * enemyVision.visionLength, enemyVision.visionLength, angle);
        }
    }
    

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _distance, float _angle)
        {
            hit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;
        }
    }


}
