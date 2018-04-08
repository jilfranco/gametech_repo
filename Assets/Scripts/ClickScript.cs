using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{   
    //[SerializeField] private Color hoverColor;
    //[SerializeField] private Color selectedColor;
    //private Material defaultMaterial;
    private SpriteRenderer sprite;
    //private bool oneHasBeenSelected;
    //public List<GameObject> selectedPieces;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnMouseOver()
    {
        sprite.color = Color.blue;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");

        if (gameObject.CompareTag("1stSelectedGP"))
        {
            Debug.Log("Unselecting 1st");
            gameObject.tag = "GridPiece";
            //oneHasBeenSelected = false;
            GridManager.gridManagerRef.selectedGridPieces.Remove(gameObject);
        }

        else if (GridManager.gridManagerRef.selectedGridPieces.Count > 0)
        {
            Debug.Log("2nd selected");
            gameObject.tag = "2ndSelectedGP";
            GridManager.gridManagerRef.selectedGridPieces.Add(gameObject);
            StartCoroutine(GridManager.gridManagerRef.MovePiece(GridManager.gridManagerRef.selectedGridPieces[0], GridManager.gridManagerRef.selectedGridPieces[1]));
        }

        else
        {
            sprite.color = Color.red;
            gameObject.tag = "1stSelectedGP";
            //oneHasBeenSelected = true;
            GridManager.gridManagerRef.selectedGridPieces.Add(gameObject);
        }

    }

    private void OnMouseExit()
    {
        if (!gameObject.CompareTag("1stSelectedGP"))
        {
            sprite.color = Color.white;
        }
    }
}
