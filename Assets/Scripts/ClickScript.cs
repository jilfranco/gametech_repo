using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material selectedMaterial;
    private Material defaultMaterial;

    private void Awake()
    {
        defaultMaterial = GetComponent<SpriteRenderer>().sharedMaterial;
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().material = hoverMaterial;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().material = selectedMaterial;
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("mouse down");
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
}
