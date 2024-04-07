using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    [SerializeField] private MoveToTarget movement;
    [SerializeField] private MiniMapPointer miniMapPointer;

    private void Start()
    {
        miniMapPointer.OnMiniMapHit = OnMiniMapHit;
    }

    private void OnMiniMapHit(RaycastHit hit)
    {
        Debug.Log(hit.point);
        movement.SetTarget(hit.point);
    }
}
