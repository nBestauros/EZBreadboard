using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            case ("GndButt"):
                SceneManager.LoadScene("3D Circuit");
                break;
            case ("ReturnButt"):
                SceneManager.LoadScene("CircuitBuilder");
                break;
            default:
                Debug.Log("Battery name not found.");
                break;
        }

        

    }
}
