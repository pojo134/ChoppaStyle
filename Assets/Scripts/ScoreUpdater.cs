using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    private int samplesCount = 0, evaporationCount = 0, buildingsDestroyedCount = 0;
    public Text samplesText, evaporationText, buildingsDestroyedText, laserEnabledText;
    public Transform sphere;
    private float notificationCounter = 0;

    // Use this for initialization
    void Start () {
        UpdateSamples(0);
        UpdateEvaporations(0);
        UpdateBuildingsDestroyed(0);

    }
	
	// Update is called once per frame
	void Update () {
		if(samplesCount >= 1)
        {
            sphere.GetComponent<ClickToMove>().BonusMode();
            UpdateSamples(-3);
        }
        if (notificationCounter > 50)
        {
            notificationCounter = 0;
        }
        notificationCounter += Time.deltaTime;

        if (notificationCounter > 2)
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
        laserEnabledText.text = s;
        laserEnabledText.enabled = true;
        notificationCounter = 0;
    }
    public void ClearUserNotify()
    {
        laserEnabledText.text = null;
        laserEnabledText.enabled = false;
    }
}
