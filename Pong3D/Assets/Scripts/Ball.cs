using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float speedX, speedZ;
    public float bounceSpeedIncre = 1.001f;   // 1 means no change, 1.1 or more means faster exponentially, 0.9 or less means slower exponentially
    public Vector3 lastVelocity;
    private Vector3 playerDefaultPos;

    private void Start() {
        playerDefaultPos = GetComponent<Transform>().position;
    }

    void StartMotion () {
        speedX = Random.Range(0, 2) == 0 ? -1 : 1;
        speedZ = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(5, 10) * speedX, 0, Random.Range(5, 10) * speedZ);
    }

    public void ResetMotion() {
        lastVelocity = new Vector3(Random.Range(5, 10) * speedX, 0, Random.Range(5, 10) * speedZ);
    }

    public void ContinueMotion() {
        GetComponent<Rigidbody>().velocity = lastVelocity;
    }

    private void OnCollisionEnter(Collision collision) {
        Vector3 temp = GetComponent<Rigidbody>().velocity;
        temp += (GetComponent<Rigidbody>().velocity * (bounceSpeedIncre * Time.deltaTime));
        GetComponent<Rigidbody>().velocity = temp;
        lastVelocity = GetComponent<Rigidbody>().velocity;
    }

    public void StopMotion() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Transform>().position = playerDefaultPos;
    }
}
