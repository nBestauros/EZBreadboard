using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterDataHandler : MonoBehaviour
{

    private List<string> elementList;



    public string GenerateDataStructure()
    {

        LinkedList<string> data = new LinkedList<string>();
        return "";
    }

    public void UpdateText()
    {
        TextMeshProUGUI text = GameObject.FindWithTag("CircuitElementsText").GetComponent<TextMeshProUGUI>();
        text.text = "";
        for(int i =0; i<elementList.Count; i++)
        {
            text.text = text.text + elementList[i]+" ";
        }
    }

    public void AddLed()
    {
        Debug.Log("hey");
        if (elementList.Count < 20)
        {
            
            elementList.Add("LED");
            UpdateText();
        }

    }

    public void AddResistor()
    {
        if(elementList.Count<20)
        {
            elementList.Add("Switch");
            UpdateText();
        }

    }

    public void AddSwitch()
    {
        if (elementList.Count < 20)
        {
            elementList.Add("Resistor");
            UpdateText();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        elementList = new List<string>(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
