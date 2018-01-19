using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballImageCreator : MonoBehaviour {

    public float rate = 2f;
    private float startRate = 0;

    public GameObject instantObject;
    public Transform pos;

    private void Start() {
        startRate = rate;
    }

    void Update () {
        if (rate > 0) {
            rate -= Time.deltaTime;
            if (rate <= 0) {
                Instantiate(instantObject, pos.position, pos.rotation);
                rate = startRate;
            }
        }
	}
}
