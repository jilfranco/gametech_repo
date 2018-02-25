using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager PlatformManagerInstance;
    public List<GameObject> platformList;
    //public GameObject platformCollider;


    private void Awake()
    {
        PlatformManagerInstance = this;

    }

    void Start()
    {
        InitializePlatforms();
    }

    private void InitializePlatforms()
    {
        for (int i = 0; i < platformList.Count; i++)
        {
            GameObject platform = platformList[i];
            Vector2 platformPosition = Vector2.zero;

            if (i !=0)
            {
                GameObject previousPlatform = platformList[i - 1];
                float previousPlatformXPos = previousPlatform.transform.localPosition.x;
                float previousPlatformWidth = previousPlatform.GetComponent<Collider2D>().bounds.size.x / 2;

                float newXPos = previousPlatformXPos + previousPlatformWidth;
                platformPosition.x = newXPos;
            }

            platform.transform.localPosition = platformPosition;
        }

        //SetCollider();
    }

    public void MovePlatform(GameObject platform)
    {
        Vector2 platformPosition = Vector2.zero;
        GameObject previousPlatform = platformList[platformList.Count - 1];

        float previousPlatformXPos = previousPlatform.transform.localPosition.x;
        float previousPlatformWidth = previousPlatform.GetComponent<Collider2D>().bounds.size.x / 2;

        platform.GetComponent<PlatformScript>().InitializePlatformTypes();

        float newXPos = previousPlatformXPos + previousPlatformWidth;
        platformPosition.x = newXPos;

        platform.transform.localPosition = platformPosition;

        platformList.RemoveAt(0);
        platformList.Add(platform);
    }

    /*
    private void SetCollider()
    {
        float size = 0f;
        for (int i = 0; i < platformList.Count; i++)
        {
            GameObject platform = platformList[i];
            size += platform.GetComponent<Collider2D>().bounds.size.x;
        }

        Vector2 colliderSize = new Vector2(size, 1);
        Vector2 colliderCenter = new Vector2(size / 2, 1);

        platformCollider.GetComponent<BoxCollider2D>().size = colliderSize;
        platformCollider.GetComponent<BoxCollider2D>().offset = colliderCenter;

        Vector2 firstPlatformPosition = platformList[0].transform.position;
        firstPlatformPosition.x -= platformList[0].GetComponent<Collider2D>().bounds.size.x / 2;
        platformCollider.transform.position = firstPlatformPosition;
    }
    */
}
