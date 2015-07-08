using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	void Start () {
		const string projectId = "8e28fe4f-15dc-454f-9ca7-e521b7f1051f";
		UnityAnalytics.StartSDK (projectId);

	}

}
