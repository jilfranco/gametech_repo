using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    [SerializeField] private GameObject playerLilFaceOh;
    private GameObject lilFace;

    private void OnCollisionEnter2D(Collision2D playerCollision)
    {
        playerCollision.transform.localScale *= 1.5f;
        StartCoroutine(UnhappyFace());
        Debug.Log("Player collison");
    }
    
    private IEnumerator UnhappyFace()
    {
        lilFace = GameObject.Find("PlayerFace");
        lilFace.SetActive(false);
        playerLilFaceOh.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        playerLilFaceOh.SetActive(false);
        lilFace.SetActive(true);
    }
}
