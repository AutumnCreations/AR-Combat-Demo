using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlane : MonoBehaviour
{
    GroundPlane[] groundPlanes;

    void Start()
    {
        groundPlanes = FindObjectsOfType<GroundPlane>();

        foreach (GroundPlane groundPlane in groundPlanes)
        {
            if (groundPlane != gameObject.GetComponent<GroundPlane>())
            { Destroy(groundPlane); }
        }
    }

    void Update()
    {

    }
}
