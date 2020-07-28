using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickImg : MonoBehaviour
{
    bool IsRed = true;
    //public void OnPointerClick(PointerEventData eventData)
    //{
       
    //    ExecuteAll(eventData);
    //}

    public void ExecuteAll(PointerEventData eventData)
    {
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject != gameObject)
            {
                ExecuteEvents.Execute(raycastResults[i].gameObject, eventData, ExecuteEvents.pointerClickHandler);
            }
        }
    }

    void ChangeColor()
    {
        this.GetComponent<Image>().color = image.color == Color.red ? Color.blue : Color.red;
    }
    GraphicRaycaster _raycaster;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        image.color = Color.red;
        _raycaster = GameObject.FindObjectOfType<GraphicRaycaster>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown (0) && IsUI())
        //{
        //    ChangeColor();
        //}
    }







}
