using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour {

    public float rotateSpeed = 1.2f;

    public Transform sunTransform;
    private Transform rotation;

    void Start() {
        rotation = sunTransform;
    }
	
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
        rotation.Rotate(new Vector3(0, (-rotateSpeed * 0.1f), 0));
        sunTransform = rotation;
    }
}
