using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectController: MonoBehaviour
{
    public ObjectSpawnerTool objectSpawnerTool;

    private Rigidbody spawnedObjectRigidbody;
    private Vector3 spawnPoint;
    private Vector3 originPoint;

    private bool objectSpawning = false;
    private readonly float spawnDuration = 0.3f;
    private float elapsedTime = 0f;

    void OnEnable ()
    {
        spawnedObjectRigidbody = GetComponent<Rigidbody> ();
    }
    void OnCollisionEnter( Collision collision )
    {
        FinishSpawningObject ();
    }
    void Update ()
    {
        if ( objectSpawning )
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp ( originPoint, spawnPoint, elapsedTime / spawnDuration );
            if ( spawnDuration <= elapsedTime )
                FinishSpawningObject ();
            float sizeReduction = elapsedTime / spawnDuration;
            transform.localScale = Vector3.one * sizeReduction;
        }
    }
    public void SpawnObject ( Vector3 gunRayOriginPoint, Vector3 gunRayHitPoint )
    {
        originPoint = gunRayOriginPoint;
        spawnPoint = gunRayHitPoint;
        objectSpawning = true;
        elapsedTime = 0;
        spawnedObjectRigidbody.useGravity = false;
        spawnPoint -= GetSpawnOffset ();
        Debug.Log ( GetSpawnOffset () );
        transform.localScale = Vector3.zero;
    }
    public void FinishSpawningObject ()
    {
        objectSpawning = false;
        spawnedObjectRigidbody.useGravity = true;
        transform.localScale = Vector3.one;
        Destroy ( this );
    }
    private Vector3 GetSpawnOffset ()
    {
        Bounds bounds = new Bounds ( this.transform.position, Vector3.zero );
        Ray ray = new Ray ( originPoint, spawnPoint );
        foreach ( Renderer childRenderer in GetComponentsInChildren<Renderer> () )
        {
            bounds.Encapsulate ( childRenderer.bounds );
        }
        transform.localScale = Vector3.one;
        return transform.InverseTransformPoint ( bounds.ClosestPoint ( ray.GetPoint ( 800f ) ) ) * 0.01F;
    }
}
