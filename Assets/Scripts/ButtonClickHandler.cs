using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{

    MasterDataHandler handler;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(CreateCircuitElement);
        handler = GameObject.FindWithTag("Master").GetComponent<MasterDataHandler>() ;
    }

    void CreateCircuitElement()
    {
        Debug.Log("hey");
        //Debug.Log("In ButtonClickHandler.cs");
        switch (gameObject.name)
        {
            case ("ResistorButt"):
                
                handler.AddResistor();
                break;
            case ("LedButt"):
                handler.AddLed();
                break;
            case ("SwitchButt"):
                handler.AddSwitch();
                break;
            default:
                Debug.Log("Battery name not found.");
                break;
        }

        

    }
}
