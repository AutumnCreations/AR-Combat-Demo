using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] Color[] colors;

    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        int randomSelection = Random.Range(0, colors.Length);
        rend = GetComponent<Renderer>();

        rend.material.color = colors[randomSelection];
    }

}
