using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private LineRenderer lr;
    public Vector3 pos1;
    public Vector3 pos2;

    public void UpdatePos(Vector3 pos1, Vector3 pos2)
    {
        this.pos1 = pos1;
        this.pos2 = pos2;
        lr.SetPosition(0, pos1);
        lr.SetPosition(1, pos2);
    }

    public void UpdatePos()
    {
        lr.SetPosition(0, pos1);
        lr.SetPosition(1, pos2);
    }

    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        Material myMat = Resources.Load("BLACK_MAT", typeof(Material)) as Material;
        lr.material = myMat;
        lr.startColor = new Color(0.3f, 0, 0);
        lr.endColor = new Color(0.3f, 0, 0);
        //lr.startWidth = 0.3f;
        //lr.endWidth = 0.3f;

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
