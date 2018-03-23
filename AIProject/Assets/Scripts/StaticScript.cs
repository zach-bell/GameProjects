using UnityEngine;
using UnityEngine.PostProcessing;

public static  class StaticScript {

	private static PostProcessingProfile profile;

	public static PostProcessingProfile Profile {
		get {
			return profile;
		}
		set {
			profile = value;
		}
	}
}
