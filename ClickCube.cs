using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickCube : MonoBehaviour 
{
    bool IsRed = true;
    GraphicRaycaster _raycaster;
    bool IsUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        eventData.pressPosition = Input.mousePosition;
        List<RaycastResult> _resultList = new List<RaycastResult>();
        _raycaster.Raycast(eventData, _resultList);
        return _resultList.Count > 0;
    }
    private void Start()
    {
        _raycaster = GameObject.FindObjectOfType<GraphicRaycaster>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsUI())
        {
            ChangeColor();
        }
    }
    void ChangeColor()
    {
        if (IsRed)
        {
            IsRed = false;
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            IsRed = true;
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
