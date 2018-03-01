using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager PlatformManagerInstance;
    public List<GameObject> platformList;

    [SerializeField] private float platformSpacingLow;
    [SerializeField] private float platformSpacingHigh;


    private void Awake()
    {
        PlatformManagerInstance = this;
    }

    void Start()
    {
        InitializePlatforms();
    }

    public void InitializePlatforms()
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

                float newPlatformWidth = platform.GetComponent<Collider2D>().bounds.size.x / 2;   
                float newPlatformXPos = previousPlatformXPos + previousPlatformWidth + newPlatformWidth;   
                platformPosition.x = newPlatformXPos + Random.Range(platformSpacingLow, platformSpacingHigh);
            }

            platform.transform.localPosition = platformPosition;
        }
    }

    public void MovePlatform(GameObject platform)
    {
        Vector2 platformPosition = Vector2.zero;
        GameObject previousPlatform = platformList[platformList.Count - 1];

        float previousPlatformXPos = previousPlatform.transform.localPosition.x;
        float previousPlatformWidth = previousPlatform.GetComponent<Collider2D>().bounds.size.x / 2;

        platform.GetComponent<PlatformScript>().InitializePlatformTypes();

        float newPlatformWidth = platform.GetComponent<Collider2D>().bounds.size.x / 2;
        float newPlatformXPos = previousPlatformXPos + previousPlatformWidth + newPlatformWidth;
        platformPosition.x = newPlatformXPos + Random.Range(platformSpacingLow, platformSpacingHigh);

        platform.transform.localPosition = platformPosition;

        platformList.RemoveAt(0);
        platformList.Add(platform);
        
    }
}
