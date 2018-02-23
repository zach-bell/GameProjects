using UnityEngine;

public static class staticSchock{

	private static bool firstPerson;

	public static bool FirstPerson {
		get {
			return firstPerson;
		}
		set {
			firstPerson = value;
		}
	}
}
