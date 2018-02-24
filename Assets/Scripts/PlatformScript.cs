using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject[] platformTypes;

    private void Awake()
    {
        InitializePlatformTypes();
    }

    public void InitializePlatformTypes()
    {
        RandomPlatformType();
    }

    private void RandomPlatformType()
    {
        int randomNumber = UnityEngine.Random.Range(0, platformTypes.Length);
        GameObject platformType = platformTypes[randomNumber];
    }
}
