using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private RectangleWorld getPosition;

    [SerializeField] private Transform target;
    [SerializeField] private RectTransform rect;

    private void Update()
    {
        var ratioPosition = getPosition.GetPosition(model.position);
        var localX = ratioPosition.x * rect.rect.width;
        var localY = ratioPosition.y * rect.rect.height;

        target.transform.localPosition = new Vector3(localX, localY, 0);
    }
}
