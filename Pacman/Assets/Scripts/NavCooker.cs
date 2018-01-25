using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class NavCooker : MonoBehaviour {

    [SerializeField]
    private NavMeshSurface[] surfaces;
    [SerializeField]
    private string toTag = "floor";
    [SerializeField]
    private bool runOneTime = true;

    private GameObject[] objectsToNav;

    private void Start() {
        if (surfaces == null) {
            objectsToNav = GameObject.FindGameObjectsWithTag(toTag);
            surfaces = new NavMeshSurface[objectsToNav.Length];
            for (int i = 0; i < objectsToNav.Length; i++) {
                surfaces[i] = objectsToNav[i].GetComponent<NavMeshSurface>();
            }
        }
        for (int i = 0; i < surfaces.Length; i++) {
            surfaces[i].BuildNavMesh();
        }
    }
}
