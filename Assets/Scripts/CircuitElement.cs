using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitElement : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offSet;

    void OnMouseDown()
    {
        Debug.Log("hey");
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offSet = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offSet;
        transform.position = curPosition;
        SendMessageUpwards("UpdatePos2");
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
