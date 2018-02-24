using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager PlatformManagerInstance;
    public List<GameObject> platformList;
    public GameObject platformCollider;

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

        SetCollider();
    }

    private void MovePlatform(GameObject platform)
    {
        Vector2 platformPosition = Vector2.zero;
        GameObject previousPlatform = platformList[platformList.Count - 1];

        float previousPlatformXPos = previousPlatform.transform.localPosition.x;
        float previousPlatformWidth = previousPlatform.GetComponent<Collider2D>().bounds.size.x / 2;

        platform.GetComponent<PlatformScript>().InitializePlatformTypes();

        float newXPos = previousPlatformXPos + previousPlatformWidth;
        platformPosition.x = newXPos;

        platform.transform.localPosition = platformPosition;
    }

    private void SetCollider()
    {
        float colliderSize = 0f;
        for (int i = 0; i < platformList.Count; i++)
        {
            GameObject platform = platformList[i];
            colliderSize += platform.GetComponent<Collider2D>().bounds.size.x;
        }
    }
}
