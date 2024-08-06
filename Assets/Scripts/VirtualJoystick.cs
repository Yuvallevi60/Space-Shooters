using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystickArea;
    private Vector2 inputVector;

    public void OnPointerDown(PointerEventData eventData)
    {
       OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        Vector2 normalizedPoint = localPoint / joystickArea.sizeDelta;

        inputVector = (normalizedPoint.magnitude > 1.0f) ? normalizedPoint.normalized : normalizedPoint;
    }

    // Restart the input vector when the touch is released
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
    }

    public Vector2 GetInputDirection()
    {
        return inputVector; 
    }
}
