using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (CreatPointsInterest))]
public class CreatePointsOfInterestEditor : Editor {

	void OnSceneGUI() {
		CreatPointsInterest control = (CreatPointsInterest)target;
		Handles.color = Color.white;

		List<Vector3> lines = new List<Vector3>();
		List<Vector3> lines2 = new List<Vector3>();
		lines.Add(control.transform.position);
		lines.Add(control.transform.position + new Vector3(control.sizeX, 0, 0));
		lines2.Add(control.transform.position + new Vector3(control.sizeX, 10, 0));
		lines2.Add(control.transform.position + new Vector3(control.sizeX, -10, 0));
		// ***************************************************
		lines.Add(control.transform.position + new Vector3(control.sizeX, 0, 0));
		lines.Add(control.transform.position + new Vector3(control.sizeX, 0, control.sizeZ));
		lines2.Add(control.transform.position + new Vector3(control.sizeX, 10, control.sizeZ));
		lines2.Add(control.transform.position + new Vector3(control.sizeX, -10, control.sizeZ));
		// ***************************************************
		lines.Add(control.transform.position + new Vector3(control.sizeX, 0, control.sizeZ));
		lines.Add(control.transform.position + new Vector3(0, 0, control.sizeZ));
		lines2.Add(control.transform.position + new Vector3(0, 10, control.sizeZ));
		lines2.Add(control.transform.position + new Vector3(0, -10, control.sizeZ));
		// ***************************************************
		lines.Add(control.transform.position + new Vector3(0, 0, control.sizeZ));
		lines.Add(control.transform.position);
		lines2.Add(control.transform.position + new Vector3(0, 10, 0));
		lines2.Add(control.transform.position + new Vector3(0, -10, 0));
		// ***************************************************
		Handles.color = Color.white;
		Handles.DrawLines(lines.ToArray());
		Handles.color = Color.magenta;
		Handles.DrawLines(lines2.ToArray());
	}
}
