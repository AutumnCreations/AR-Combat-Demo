using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrentSelectionDisplay : MonoBehaviour
{
    TextMeshProUGUI tmPro;


    void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
        tmPro.text = "";
    }

    internal void UpdateDisplay(string objectToDisplay)
    {
        tmPro.text = objectToDisplay;
    }
}
