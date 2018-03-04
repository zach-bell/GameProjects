using UnityEngine;

public static  class StaticScript {

	private static bool flashLight;

	public static bool FlashLight {
		get {
			return flashLight;
		}
		set {
			flashLight = value;
		}
	}
}
