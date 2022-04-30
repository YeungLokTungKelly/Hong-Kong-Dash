using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    public bool powerupActive;
    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float flyRate;

    private PlatformDestroyer[] flyList;

    
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //Set the time duration for powerups
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.75f;
                theScoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                thePlatformGenerator.randomFlyThreshold = 0f;
            }

            //Deactivate powerups after the a set peroid of time
            if(powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomFlyThreshold = flyRate;
                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        flyRate = thePlatformGenerator.randomFlyThreshold;
        if (safeMode)
        {
            flyList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < flyList.Length; i++)
            {
                if (flyList[i].gameObject.name.Contains("fly"))
                {
                    flyList[i].gameObject.SetActive(false);
                }
                   
            }
        }
        powerupActive = true;

    }
}
