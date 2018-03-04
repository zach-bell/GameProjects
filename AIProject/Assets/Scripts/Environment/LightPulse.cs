using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightPulse : MonoBehaviour {
	[SerializeField]
	private float minIntensity = 0.5f;
	[SerializeField]
	private float maxIntensity = 1f;
	[SerializeField]
	private float speed = 0.24f;
	
	private float lastRand = 0;
	private float smothVel;

	void LateUpdate () {
		lastRand = Mathf.SmoothDamp(lastRand, Random.Range(minIntensity, maxIntensity), ref smothVel, speed);
		GetComponent<Light>().intensity = lastRand;
	}
}
