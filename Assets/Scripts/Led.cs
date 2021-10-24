using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : CircuitElement
{
    Wire wireToPrev;
    RectTransform rt;
    bool isLast = true;
    // Start is called before the first frame update
    void Start()
    {
        rt = transform as RectTransform;
        wireToPrev = new GameObject().AddComponent<Wire>();
        UpdatePos2();
        wireToPrev.UpdatePos();
        
    }

    void UpdatePos2()
    {
        Debug.Log("Yo");
        wireToPrev.pos2.x = transform.position.x;
        wireToPrev.pos2.y = transform.position.y;
        wireToPrev.pos2.z = 89;
    }


    public void setPos1(RectTransform posAtCenter)
    {
        
        wireToPrev.pos1.x = transform.position.x - (1 / 2 * posAtCenter.rect.width);
        wireToPrev.pos2.y = transform.position.y - (1 / 2 * posAtCenter.rect.height);
        wireToPrev.pos1.z = 89;
        wireToPrev.UpdatePos();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
