using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();      
    }

    public void ShowTrajectory(Vector3 ballOrigin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = ballOrigin + speed * time + Physics.gravity * time * time / 2;

            if(points[i].y < -0.2 || points[i].x > 9)
            {
                lineRenderer.positionCount = i + 1;
                break;
            }
        }
        lineRenderer.SetPositions(points);
    }
}
