using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraCCheck : MonoBehaviour {
    
	void Start () {
        if (StaticScript.CcOff)
            GetComponent<PostProcessingBehaviour>().enabled = true;
        else
            GetComponent<PostProcessingBehaviour>().enabled = false;
    }
}
