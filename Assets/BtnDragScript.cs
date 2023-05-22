using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnDragScript : MonoBehaviour, IDragHandler
{
    Vector2 CurrentPos;
    Vector3 NewPos;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Debug.Log("Pos" + rectTransform.position);
        Debug.Log("AnchorPos" + rectTransform.anchoredPosition);

    }
    private void Update()
    {
        CurrentPos = RectTransformUtility.WorldToScreenPoint(new Camera(), transform.position);
        CurrentPos.x = Mathf.Clamp(CurrentPos.x, 0, Screen.width);
        CurrentPos.y = Mathf.Clamp(CurrentPos.y, 0, Screen.height);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, CurrentPos, new Camera(), out NewPos);
        transform.position = NewPos;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draged");
        // Calculate the new position of the UI button based on touch input
        // rectTransform.anchoredPosition += eventData.delta;
        transform.position = eventData.position;
    }
}
