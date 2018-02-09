using UnityEngine;

public class CreatPointsInterest : MonoBehaviour {

	[Header("These objects should have the FieldOfView component")]
	[Header("and the Ghost (Script) component")]
	[TagSelector]
	public string ObjectsToSetTargets = "";
	[Header("Set the target prefab")]
	[Tooltip("This would be the PointsOfInterest Prefab")]
	[SerializeField]
	private GameObject PointOfInterest;

	[Header("Area to create points inside")]
	public float sizeX = 10;
	public float sizeZ = 10;

	private GameObject[] objectList;
	private GameObject[] pointsOfInterestList;

	void Start () {
		objectList = GameObject.FindGameObjectsWithTag(ObjectsToSetTargets);
		pointsOfInterestList = new GameObject[objectList.Length];
		createPointsOfInterest();
		setTargetsOfInterest();
	}

	private void createPointsOfInterest() {
		for (int i=0; i < pointsOfInterestList.Length; i++) {
			pointsOfInterestList[i] = Instantiate(PointOfInterest,
				new Vector3(Random.Range(transform.position.x, sizeX), transform.position.y, Random.Range(transform.position.z, sizeZ)), transform.rotation);
		}
	}

	public void setTargetsOfInterest() {
		for (int i=0; i < objectList.Length; i++) {
			objectList[i].GetComponent<Ghost>().target = pointsOfInterestList[i];
		}
	}

	private void movePointsOfInterest() {
		for (int i=0; i < pointsOfInterestList.Length; i++) {
			pointsOfInterestList[i].GetComponent<Transform>().position = new Vector3(Random.Range(transform.position.x, sizeX), transform.position.y, Random.Range(transform.position.z, sizeZ));
		}
	}

	private float count = 0;
	private float waitTime = 8;

	void Update () {
		count += Time.deltaTime;
		if (count >= waitTime) {
			movePointsOfInterest();
			count = 0;
			waitTime = Random.Range(8, 16);
		}
	}
}
