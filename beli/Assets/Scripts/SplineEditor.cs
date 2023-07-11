using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SplineEditor : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;
    public GameObject controlPointPrefab;

    private List<GameObject> controlPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // init sprite shape controller
        spriteShapeController = GetComponent<SpriteShapeController>();
        
        Spline spline = spriteShapeController.spline;
        int pointCount = spline.GetPointCount();

        // add control points to spline
        for (int i = 0; i < pointCount; i++)
        {
            Vector3 point = spline.GetPosition(i);
            GameObject controlPoint = Instantiate(controlPointPrefab, point, Quaternion.identity);
            controlPoints.Add(controlPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Spline spline = spriteShapeController.spline;
        int pointCount = spline.GetPointCount();

        // update control points
        for (int i = 0; i < controlPoints.Count; i++)
        {
            GameObject controlPoint = controlPoints[i];
            Vector3 point = spline.GetPosition(i);
            controlPoint.transform.position = point;
        }

    }
}
