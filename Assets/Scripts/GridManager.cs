using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager gridManagerRef;

    public List<GameObject> activeGridPieces;
    public List<Vector2> originalPositions;
    public List<GameObject> selectedGridPieces;

    private void Awake()
    {
        gridManagerRef = this;
        activeGridPieces = GameObject.FindGameObjectsWithTag("GridPiece").OrderBy(GetGridPieceIndex).ToList();
    }

    private int GetGridPieceIndex(GameObject gridPiece)
    {
        string pieceName = gridPiece.name;
        int pieceNameAsNumber = int.Parse(pieceName);
        return pieceNameAsNumber;
    }

    void Start()
    {
        ShuffleGridPieces();
    }

    private void ShuffleGridPieces()
    {
        for (int i = 0; i < activeGridPieces.Count; ++i)
        {
            Vector2 originalPos = activeGridPieces[i].transform.position;
            originalPositions.Add(originalPos);
        }

        var positionCopy = new List<Vector2>(originalPositions);
        for (int i = 0; i < activeGridPieces.Count; ++i)
        {
            int randomIndex = Random.Range(0, positionCopy.Count - 1);
            activeGridPieces[i].transform.position = positionCopy[randomIndex];
            positionCopy.RemoveAt(randomIndex);
        }
    }

    public IEnumerator MovePiece(GameObject firstGridPiece, GameObject secondGridPiece)
    {
        Vector2 firstGPOGPos = firstGridPiece.transform.position;
        Vector2 secondGPOGPos = secondGridPiece.transform.position;
        firstGridPiece.transform.position = secondGPOGPos;
        secondGridPiece.transform.position = firstGPOGPos;
        yield return new WaitForSeconds(0);
    }

    public bool InOriginalSpot(GameObject gridPiece)
    {
        bool inOriginalSpot;
        int index = GetGridPieceIndex(gridPiece);
        Vector2 originalPosition = originalPositions[index];

        if (Vector2.Distance(originalPosition, gridPiece.transform.position) < 0.05f)
        {
            inOriginalSpot = true;
            gridPiece.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            inOriginalSpot = false;
        }
        return inOriginalSpot;
    }
}
