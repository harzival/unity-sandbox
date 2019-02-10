using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerTool : MonoBehaviour
{
    public GameObject objectPrefab;

    private ToolGunController toolGunController;
    private Transform spawnedObject;
    private Vector3 gunRayHitPoint;
    private Vector3 gunRayOriginPoint;

    void OnEnable ()
    {
        toolGunController = GetComponent<ToolGunController> ();
    }

    void Update ()
    {
        if ( Input.GetMouseButtonDown ( 0 ) ) 
        {
            FireToolGun ();
        }
    }

    public void FireToolGun ()
    {
        if ( objectPrefab != null )
        {
            spawnedObject = Instantiate ( objectPrefab, transform.position, Quaternion.identity ).transform;
            spawnedObject.localScale = new Vector3 ( 0, 0, 0 );
            SpawnedObjectController spawnedObjectController = spawnedObject.gameObject.AddComponent<SpawnedObjectController> ();
            spawnedObjectController.SpawnObject ( transform.position, toolGunController.playerGazeHit.point );
        }
    }
}
