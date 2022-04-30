using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformsSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomFlyThreshold;
    public ObjectPooler flyPool;

    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;

    void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformsSelector = Random.Range(0, theObjectPools.Length); //randomly choose between the 4 platforms created in Unity
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            if(Random.Range(0f,100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(0f, powerupHeight), 0f);
                newPowerup.SetActive(true);
                     
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformsSelector] / 2) + distanceBetween, heightChange, transform.position.z);
         

            GameObject newPlatform = theObjectPools[platformsSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f,100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomFlyThreshold)
            {
                GameObject newFly = flyPool.GetPooledObject();

                float flyXPosition = Random.Range(-platformWidths[platformsSelector] / 2, platformWidths[platformsSelector] / 2);
                
                //Randomly place the obstacles within the platform width
                Vector3 flyPosition = new Vector3(flyXPosition, 0.5f, 0f);
                newFly.transform.position = transform.position + flyPosition;
                newFly.transform.rotation = transform.rotation;
                newFly.SetActive(true);

            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformsSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);
        }
    }
}
