using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemController : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject toolGun;
    private Button button;

    private bool fireToolGunOnTileClick = true;

    // Start is called before the first frame update
    void Start()
    {
         button = gameObject.GetComponent<Button> ();
         button.onClick.AddListener ( OnButtonClick );

        toolGun = GameObject.FindWithTag ( "toolGun" );
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClick()
    {
        ObjectSpawnerTool objectSpawnerTool = toolGun.GetComponent<ObjectSpawnerTool> ();
        if ( ! objectSpawnerTool )
        {
            toolGun.AddComponent(typeof(ObjectSpawnerTool));
        }
        objectSpawnerTool.objectPrefab = objectPrefab;
        if ( fireToolGunOnTileClick )
            objectSpawnerTool.FireToolGun ();
    }
}
