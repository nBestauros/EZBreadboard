using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(CreateCircuitElement);
    }

    void CreateCircuitElement()
    {
        //Debug.Log("In ButtonClickHandler.cs");
        switch (gameObject.name)
        {
            case ("ReturnButt"):
                SceneManager.LoadScene("CircuitBuilder");
                break;
            default:
                Debug.Log("Battery name not found.");
                break;
        }

        

    }
}
