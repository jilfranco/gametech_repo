using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public static GridManager gridManagerRef;
	
	private int piecesLeft;

	[SerializeField] private Text piecesLeftText;
	
	[SerializeField] private List<int> ignoredTiles;
	[SerializeField] private List<GameObject> activeGridPieces;
    [SerializeField] private List<Vector2> originalPositions;
    [SerializeField] public List<GameObject> selectedGridPieces;

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

		var usedPositions = new List<int>();

		for (int i = 0; i < activeGridPieces.Count; ++i)
        {
			if (ignoredTiles.Contains(i))
				continue;

            int randomIndex;
	        do
	        {
				randomIndex = Random.Range(0, originalPositions.Count - 1);
	        } while (ignoredTiles.Contains(randomIndex) || usedPositions.Contains(randomIndex));

            activeGridPieces[i].transform.position = originalPositions[randomIndex];
            usedPositions.Add(randomIndex);
        }

	    piecesLeft = originalPositions.Count - activeGridPieces.Count(InOriginalSpot);
	    piecesLeftText.text = "Unsorted Pieces Left: " + piecesLeft;
		

	    //activeGridPieces[102].transform.position = originalPositions[57];
	    //activeGridPieces[57].transform.position = originalPositions[102];
    }

    public IEnumerator MovePiece(GameObject firstGridPiece, GameObject secondGridPiece)
    {
        Vector2 firstGPOGPos = firstGridPiece.transform.position;
        Vector2 secondGPOGPos = secondGridPiece.transform.position;
        firstGridPiece.transform.position = secondGPOGPos;
        secondGridPiece.transform.position = firstGPOGPos;
		firstGridPiece.GetComponent<SpriteRenderer>().color = Color.white;
		selectedGridPieces.Clear();
        yield return new WaitForSeconds(0);

	    piecesLeft = originalPositions.Count - activeGridPieces.Count(InOriginalSpot);

	    piecesLeftText.text = "Unsorted Pieces Left: " + piecesLeft;

	    if (activeGridPieces.All(InOriginalSpot))
	    {
		    SceneManager.LoadScene("Scene_End");
			Debug.Log("hello you've beaten it");
	    }
    }

    public bool InOriginalSpot(GameObject gridPiece)
    {
        bool inOriginalSpot;
        int index = GetGridPieceIndex(gridPiece);
        Vector2 originalPosition = originalPositions[index];

        if (Vector2.Distance(originalPosition, gridPiece.transform.position) < 0.05f)
        {
            inOriginalSpot = true;
	        var pieceCollider = gridPiece.GetComponent<Collider2D>();
	        if (pieceCollider != null)
		        pieceCollider.enabled = false;
        }
        else
        {
            inOriginalSpot = false;
        }
        return inOriginalSpot;
    }

	public void ClickQuitGame()
	{
		SceneManager.LoadScene("Scene_Menu");
	}
}
