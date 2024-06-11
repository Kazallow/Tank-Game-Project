using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color newColor = Color.yellow; 

    void Start()
    {
        GetComponent<Renderer>().material.color = newColor;
    }
}
