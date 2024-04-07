using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleWorld : MonoBehaviour
{
    [SerializeField] private Transform pointTopLeft;
    [SerializeField] private Transform pointTopRight;
    [SerializeField] private Transform pointBottomLeft;
    [SerializeField] private Transform pointBottomRight;

    public Vector3 GetCenter()
    {
        return (pointTopLeft.position + pointTopRight.position + pointBottomLeft.position + pointBottomRight.position) / 4;
    }

    public float GetWidth()
    {
        return Mathf.Abs(pointTopLeft.position.x - pointTopRight.position.x);
    }
    public float GetHeight()
    {
        return Mathf.Abs(pointTopLeft.position.z - pointBottomLeft.position.z);
    }

    public Vector2 GetPosition(Vector3 position)
    {
        var center = GetCenter();
        return new Vector2((position.x - center.x) / GetWidth(), (position.z - center.z) / GetHeight());
    }
}
