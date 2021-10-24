using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscKeyPress : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("CircuitBuilder");
        }
    }
}
