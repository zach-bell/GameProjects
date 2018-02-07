using UnityEngine;

public class CreatPointsInterest : MonoBehaviour {

	[Header("Set the Objects")]
	[TagSelector]
	public string ObjectsToSetTargets = "";
	[Tooltip("This would be the PointsOfInterest Prefab")]
	[SerializeField]
	private GameObject PointsOfInterest;

	[Header("Area to create points inside")]
	public float sizeX = 10;
	public float sizeZ = 10;

	private GameObject[] objectList;

	void Start () {
		objectList = GameObject.FindGameObjectsWithTag(ObjectsToSetTargets);
	}
	
	void Update () {
		
	}
}
