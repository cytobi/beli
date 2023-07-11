using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SplineEditor : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;
    public GameObject controlPointPrefab;

    private List<GameObject> controlPoints = new List<GameObject>();
    private List<GameObject> leftTangentPoints = new List<GameObject>();
    private List<GameObject> rightTangentPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // init sprite shape controller
        spriteShapeController = GetComponent<SpriteShapeController>();
        
        Spline spline = spriteShapeController.spline;
        int pointCount = spline.GetPointCount();

        // add control points and tangents to spline
        for (int i = 0; i < pointCount; i++)
        {
            Vector3 point = spline.GetPosition(i);
            Vector3 leftTangent = spline.GetLeftTangent(i);
            Vector3 rightTangent = spline.GetRightTangent(i);
            GameObject controlPoint = Instantiate(controlPointPrefab, point, Quaternion.identity);
            controlPoints.Add(controlPoint);
            GameObject leftTangentPoint = Instantiate(controlPointPrefab, point + leftTangent, Quaternion.identity);
            leftTangentPoints.Add(leftTangentPoint);
            GameObject rightTangentPoint = Instantiate(controlPointPrefab, point + rightTangent, Quaternion.identity);
            rightTangentPoints.Add(rightTangentPoint);
        }

        // deactivate tangent points at ends of spline (they technically don't exist)
        leftTangentPoints[0].SetActive(false);
        rightTangentPoints[pointCount - 1].SetActive(false);
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
