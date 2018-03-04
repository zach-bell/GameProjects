using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public GameObject thing;

    public void remove() {
        Destroy(thing);
    }
}
