using UnityEngine;

public static class StaticOptions {

    private static bool p2AI;

    public static bool P2AI {
        get {
            return p2AI;
        }
        set {
            p2AI = value;
        }
    }
}
