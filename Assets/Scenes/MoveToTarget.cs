using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private Vector3 target;
    [SerializeField] private float speed;
    [SerializeField] private float distanceComplete;

    private Action _onMovedEnd;
    private bool _isMoving = false;

    public MoveToTarget SetOnMoveEnd(Action onMoveEnd)
    {
        _onMovedEnd = onMoveEnd;
        return this;
    }
    public MoveToTarget SetTarget(Vector3 target)
    {
        this.target = target;
        return this;
    }
    public void Run()
    {
        _isMoving = true;
    }

    private void FixedUpdate()
    {
        if (target == null) return;
        model.transform.position = Vector3.MoveTowards(
            model.transform.position,
            target,
            Time.deltaTime * speed
         );
        if(Vector3.Distance(model.transform.position, target) < distanceComplete )
        {
            _onMovedEnd?.Invoke();
        }
    }

}
