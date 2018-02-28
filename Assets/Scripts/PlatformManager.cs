using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager PlatformManagerInstance;
    public List<GameObject> platformList;
    public List<GameObject> activePlatformList;

    [SerializeField] private float platformSpacingLow;
    [SerializeField] private float platformSpacingHigh;


    private void Awake()
    {
        PlatformManagerInstance = this;
    }

    void Start()
    {
        platformList = GameObject.FindGameObjectsWithTag("Platform").ToList();
        InitializePlatforms();
        //InitializePlatforms();
    }

    public void InitializePlatforms()
    {
        activePlatformList = new List<GameObject>();
        foreach (GameObject platform in activePlatformList)
        {
            activePlatformList.Add(platform);
            //MovePlatform(platform);
        }

    }

    public void DeactivatePlatform(GameObject inactivePlatform)
    {
        activePlatformList.Remove(inactivePlatform);
        MovePlatform(inactivePlatform);
    }

    public void MovePlatform(GameObject platform)
    {
        Vector2 platformPosition = Vector2.zero;
        GameObject previousPlatform = platformList[platformList.Count - 1];

        float previousPlatformXPos = previousPlatform.transform.localPosition.x;
        float previousPlatformWidth = previousPlatform.GetComponent<Collider2D>().bounds.size.x / 2;

        float newPlatformWidth = platform.GetComponent<Collider2D>().bounds.size.x / 2;
        float newPlatformXPos = previousPlatformXPos + previousPlatformWidth + newPlatformWidth;
        platformPosition.x = newPlatformXPos + Random.Range(platformSpacingLow, platformSpacingHigh);

        platform.transform.localPosition = platformPosition;
    }


    /*
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

                float newPlatformWidth = platform.GetComponent<Collider2D>().bounds.size.x / 2;   
                float newPlatformXPos = previousPlatformXPos + previousPlatformWidth + newPlatformWidth;   
                platformPosition.x = newPlatformXPos + Random.Range(platformSpacingLow, platformSpacingHigh);
            }

            platform.transform.localPosition = platformPosition;
        }
    }


    }*/
    }
