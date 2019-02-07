using UnityEngine;

public class Remove : MonoBehaviour
{
    public float Range = 100f;

    public Camera playerCam;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, Range)){
            Destroy(hit.transform.gameObject);
        }
    }

}
