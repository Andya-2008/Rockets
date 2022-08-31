using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragPowerup : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DragHandler(BaseEventData data)
    {
        GetComponent<MovePowerup>().move = false;
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position,canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
    }
    public void DropHandler()
    {
        GetComponent<MovePowerup>().move = true;
    }
}
