using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticScript {

    private static bool ccOff;
	private static int gameScore = 0;

	public static int GameScore {
		get {
			return gameScore;
		}
		set {
			gameScore = value;
		}
	}

	public static bool CcOff {
        get {
            return ccOff;
        }
        set {
            ccOff = value;
        }
    }
}
