using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputUIElementTracker : MonoBehaviour, IPointerDownHandler , IPointerUpHandler, IDragHandler, IPointerExitHandler
{

    [SerializeField] private float distanceToDrag;
    
    private Vector3 _pointerDownPosition;
    private Vector3 _lastPosition;
    private bool _isDownning = false;
    private bool _isDrag = false;
    
    
    #region Impletement interface

    public Action<PointerEventData> OnClick { get; set; }
    public Action<Vector3, Vector3> OnDragEvent { get; set; }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _pointerDownPosition = Input.mousePosition;
        _lastPosition = Input.mousePosition;
        _isDownning = true;
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EndRecordDown(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _isDrag = true;
        if (!_isDownning) return;
        if (Vector3.Distance(Input.mousePosition, _pointerDownPosition) < distanceToDrag) return;
        OnDragEvent?.Invoke(_lastPosition, Input.mousePosition);
        _lastPosition = Input.mousePosition;
    }
    private void EndRecordDown(PointerEventData eventData)
    {
        if (_isDrag)
        {
            _isDrag = false;
            _isDownning = false;
            return;
        }
        if (!_isDownning) return;
        _isDownning = false;

        OnClick?.Invoke(eventData);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        EndRecordDown(eventData);
    }
    

    #endregion
}