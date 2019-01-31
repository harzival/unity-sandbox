using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private GameObject Camera;
    public GameObject wheelPrefab;
    private Vector3 SpawnPosition;
    private int DistanceToCamera = 5;

    void Start () {
         Camera = (GameObject) GameObject.FindWithTag("MainCamera");
     }

    private void Update() {
        if (Input.GetKeyDown("o")) {
            SpawnPosition = Camera.transform.forward * DistanceToCamera + Camera.transform.position;
            Instantiate(wheelPrefab, SpawnPosition, Quaternion.identity);
        }
    }

}
