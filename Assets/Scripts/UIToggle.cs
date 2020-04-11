using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIToggle : MonoBehaviour
{
    [SerializeField] GameObject objectToPlace = null;

    TextMeshProUGUI textMeshPro;

    PlayerInteraction playerInteraction;
    CurrentSelectionDisplay selectionDisplay;

    void Start()
    {
        selectionDisplay = FindObjectOfType<CurrentSelectionDisplay>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        textMeshPro.text = objectToPlace.name;
    }

    public void SetObjectToPlace()
    {
        playerInteraction.PlaceObject(objectToPlace);
        selectionDisplay.UpdateDisplay(objectToPlace.name);
    }
}
