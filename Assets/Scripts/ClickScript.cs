using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{   
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
	    if (!gameObject.CompareTag("1stSelectedGP"))
	    {
			sprite.color = Color.cyan;
	    }
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");

        if (gameObject.CompareTag("1stSelectedGP"))
        {
            gameObject.tag = "GridPiece";
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
            sprite.color = Color.magenta;
            gameObject.tag = "1stSelectedGP";
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
