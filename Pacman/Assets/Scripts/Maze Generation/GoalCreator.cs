using UnityEngine;

public class GoalCreator : MonoBehaviour {

    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float percentage = 0.8f;

	void Start () {
        if(Random.value >= percentage)
            Instantiate(goal, (transform.position + offset), transform.rotation);
    }
}
