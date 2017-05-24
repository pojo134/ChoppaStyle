using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    private int samplesCount = 0, evaporationCount = 0, buildingsDestroyedCount = 0;
    public Text samplesText, evaporationText, buildingsDestroyedText, notifyText;
    public Transform sphere;
    public float notificationCounter = 0;
    public int sampleCost = 1, buildingCost = 1, evapCost = 1;


    // Use this for initialization
    void Start () {
        UpdateSamples(0);
        UpdateEvaporations(0);
        UpdateBuildingsDestroyed(0);

    }
	
	// Update is called once per frame
	void Update () {
		if(samplesCount >= sampleCost)
        {
            sphere.GetComponent<ClickToMove>().BonusMode();
            UpdateSamples(-sampleCost);
        }
        if (buildingsDestroyedCount >= buildingCost)
        {
            sphere.GetComponent<ClickToMove>().BuildingBonusMode();
            UpdateBuildingsDestroyed(-buildingCost);
        }
        if (evaporationCount >= evapCost)
        {
            //TODO: Make some bonus for the evaporations
        }
        if (notificationCounter > 10)
        {
            notificationCounter = 2;
        }
        notificationCounter += Time.deltaTime;

        if (notificationCounter > 1)
        {
            ClearUserNotify();
        }

	}

    public void UpdateBuildingsDestroyed(int b)
    {
        buildingsDestroyedCount += b;
        buildingsDestroyedText.text = "BuildingsDestroyed: " + buildingsDestroyedCount;

    }

    public void UpdateEvaporations(int e)
    {
        evaporationCount += e;
        evaporationText.text = "Evaporations: " + evaporationCount;
    }

    public void UpdateSamples(int s)
    {
        samplesCount += s;
        samplesText.text = "Samples: " + samplesCount;
    }

    public void NotifyUser(string s)
    {
        notifyText.text = s;
        notifyText.enabled = true;
        notificationCounter = 0;
    }
    public void ClearUserNotify()
    {
        notifyText.text = null;
        notifyText.enabled = false;
    }
}
