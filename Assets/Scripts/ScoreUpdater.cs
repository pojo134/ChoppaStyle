using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    private int samplesCount = 0, evaporationCount = 0, buildingsDestroyedCount = 0;
    public Text samplesText, evaporationText, buildingsDestroyedText;

    // Use this for initialization
    void Start () {
        UpdateSamples(0);
        UpdateEvaporations(0);
        UpdateBuildingsDestroyed(0);

    }
	
	// Update is called once per frame
	void Update () {
		
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
}
