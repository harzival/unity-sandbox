using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float Range = 100f;
    public Camera playerCam;
    public GameObject wheelPrefab;

    private void Update() {
        if (Input.GetKeyDown("o")) {
            SpawnPrefab();
        }
    }

    void SpawnPrefab() {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, Range)) {
            Instantiate(wheelPrefab, hit.point, Quaternion.identity);
        }
    }

}
