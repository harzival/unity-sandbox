using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ObjectListController : MonoBehaviour
{
    public RectTransform listItemPrefab;
    private RectTransform contentRectTransform;
    private float listPosX = 14.25F;
    private float listPosY = -14.25F;

    void Start ()
    {
        contentRectTransform = this.GetComponent<RectTransform> ();

        // Define the path to the "Objects" mod folder.
        string objectsDir = Path.Combine ( Application.streamingAssetsPath + "/Objects" );
        // Get a list of AssetBundles in the "Objects" mod folder.
        string [] objectsDirFileList = Directory.GetFiles ( objectsDir, "*.assetbundle" );

        int objectsCounter = 0;
        for ( int i = 0; i < 10; i++ )
        {
            for ( int j = 0; j < 6; j++ )
            {
                if ( objectsCounter != objectsDirFileList.Length )
                {
                    RectTransform currentTile = Instantiate ( listItemPrefab, contentRectTransform );
                    GameObject objectPrefab = LoadObjectFromAssetBundle ( objectsDirFileList [ objectsCounter ] );
                    currentTile.GetComponent<ListItemController> ().objectPrefab = objectPrefab;
                    currentTile.anchoredPosition = new Vector2 ( listPosX, listPosY );
                    currentTile.GetComponentInChildren<TextMeshProUGUI> ().SetText(objectPrefab.name);
                    objectsCounter++;
                    listPosX += 4.25F + 20;
                }
                else
                {
                    break;
                }
            }
            listPosY += -7.25F - 20;
            listPosX = 14.25F;
        }

    }
    GameObject LoadObjectFromAssetBundle ( string objectFilePath )
    {
        AssetBundle objectAssetBundle = AssetBundle.LoadFromFile ( objectFilePath );
        return objectAssetBundle.LoadAsset<GameObject> ( "Sphere" ); 
    }
    void PopulateObjectListGrid ()
    {

    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListController : MonoBehaviour
{
    public RectTransform listItemPrefab;
    private RectTransform contentRectTransform;
    private float listPosX = 14.25F;
    private float listPosY = -14.25F;

    void Start ()
    {
        contentRectTransform = this.GetComponent<RectTransform> ();
        for ( int i = 0; i < 10; i++ ) {
            for ( int j = 0; j < 6; j++ )
            {
                RectTransform currentObj = Instantiate ( listItemPrefab, contentRectTransform );
                currentObj.anchoredPosition = new Vector2 ( listPosX, listPosY );
                listPosX += 4.25F + 20;
            }
            listPosY += -7.25F - 20;
            listPosX = 14.25F;
        }
        
    }
    void PopulateObjectListGrid ()
    {

    }
}
*/
