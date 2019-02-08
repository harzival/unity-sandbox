using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemController : MonoBehaviour
{
    Button button;
    public GameObject objectPrefab;
    // Start is called before the first frame update
    void Start()
    {
         button = gameObject.GetComponent<Button> ();
         button.onClick.AddListener ( OnButtonClick );
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClick()
    {
        Instantiate ( objectPrefab, transform.position + ( new Vector3 ( 0, 3, 0 ) ), Quaternion.identity );
    }
}
