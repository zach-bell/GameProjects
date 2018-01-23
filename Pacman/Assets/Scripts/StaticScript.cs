using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticScript {

    private static bool ccOff;

    public static bool CcOff {
        get {
            return ccOff;
        }
        set {
            ccOff = value;
        }
    }
}
