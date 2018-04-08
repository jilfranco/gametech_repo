using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager gridManagerRef;

    public List<GameObject> activeGridPieces;
    public List<Vector2> originalPositions;

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

    private void MovePiece(GameObject firstGridPiece, GameObject secondGridPiece)
    {
        Vector2 ogPos = firstGridPiece.transform.position;
        Vector2 newPos = secondGridPiece.transform.position;
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
