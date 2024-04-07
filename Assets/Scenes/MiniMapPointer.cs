using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniMapPointer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera miniMapCam;
    [SerializeField] private RawImage rawImageMapView;
    
    public Action<RaycastHit> OnMiniMapHit { get; set; }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 curosr = new Vector2(0, 0);

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImageMapView.rectTransform,
            eventData.pressPosition, eventData.pressEventCamera, out curosr))
        {

            Texture texture = rawImageMapView.texture;
            Rect rect = rawImageMapView.rectTransform.rect;

            float coordX = Mathf.Clamp(0, (((curosr.x - rect.x) * texture.width) / rect.width), texture.width);
            float coordY = Mathf.Clamp(0, (((curosr.y - rect.y) * texture.height) / rect.height), texture.height);

            float calX = coordX / texture.width;
            float calY = coordY / texture.height;


            curosr = new Vector2(calX, calY);

            CastRayToWorld(curosr);
        }
    }

    private void CastRayToWorld(Vector2 vec)
    {
        Ray MapRay = miniMapCam.ScreenPointToRay(new Vector2(vec.x * miniMapCam.pixelWidth,
            vec.y * miniMapCam.pixelHeight));

        RaycastHit miniMapHit;

        if (Physics.Raycast(MapRay, out miniMapHit, Mathf.Infinity))
        {
            OnMiniMapHit?.Invoke(miniMapHit);
        }
    }
}
