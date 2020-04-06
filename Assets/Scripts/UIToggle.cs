using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIToggle : MonoBehaviour
{
    [SerializeField] GameObject objectToPlace = null;

    PlayerInteraction playerInteraction;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        textMeshPro.text = objectToPlace.name;
    }

    public void SetObjectToPlace()
    {
        playerInteraction.PlaceObject(objectToPlace);
    }
}
