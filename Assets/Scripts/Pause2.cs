using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause2 : MonoBehaviour
{
    public InputActionReference oButtonAction;

    private void OnEnable()
    {
        
        oButtonAction.action.Enable();
    }

    private void OnDisable()
    {
        
        oButtonAction.action.Disable();
    }

    void Update()
    {
        
        if (oButtonAction.action.triggered)
        {
            
            SceneManager.LoadScene(5);
        }
    }
}
