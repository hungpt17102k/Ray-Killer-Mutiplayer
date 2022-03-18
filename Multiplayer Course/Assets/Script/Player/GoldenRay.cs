using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenRay : MonoBehaviour
{
    LineRenderer rend;
    EdgeCollider2D col;
    LineRenderer layerSort;

    public List<Vector2> linePoints = new List<Vector2>();

    private void Start()
    {
        rend = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
        layerSort = GetComponent<LineRenderer>();
        layerSort.sortingOrder = -1;
    }

    private void Update()
    {
        linePoints[0] = rend.GetPosition(0);
        linePoints[1] = rend.GetPosition(1);

        // To store line point to the edge point of the egde coillsion
        col.points = linePoints.ToArray();
    }
}
