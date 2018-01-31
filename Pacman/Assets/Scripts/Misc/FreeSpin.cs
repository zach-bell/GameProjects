using UnityEngine;

[RequireComponent(typeof(Transform))]
public class FreeSpin : MonoBehaviour {

    [SerializeField]
    private float RotationSpeed = 1;
    [SerializeField]
    private float MinSpin = 0;
    [SerializeField]
    private float MaxSpin = 100;
    private Vector3 rotationVector;
    
    void Start () {
        rotationVector = new Vector3(Random.Range(MinSpin, MaxSpin), Random.Range(MinSpin, MaxSpin), Random.Range(MinSpin, MaxSpin));
	}
	
	void Update () {
        transform.Rotate(rotationVector * (RotationSpeed * Time.deltaTime), Space.Self);
	}
}
