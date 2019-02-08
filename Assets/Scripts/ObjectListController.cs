using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        RuntimePreviewGenerator.BackgroundColor = Color.clear;

        // Define the path to the "Objects" mod folder.
        string objectsDir = Path.Combine ( Application.streamingAssetsPath + "/Objects" );
        // Get a list of AssetBundles in the "Objects" mod folder.
        string [] objectsDirFileList = Directory.GetFiles ( objectsDir, "*.object" );

        int objectsCounter = 0;
        for ( int i = 0; i < 10; i++ )
        {
            for ( int j = 0; j < 6; j++ )
            {
                if ( objectsCounter != objectsDirFileList.Length )
                {
                    GameObject objectPrefab = LoadObjectFromAssetBundle ( objectsDirFileList [ objectsCounter ] );
                    if ( objectPrefab != null )
                    {
                        RectTransform currentTile = Instantiate ( listItemPrefab, contentRectTransform );
                        currentTile.GetComponent<ListItemController> ().objectPrefab = objectPrefab;
                        currentTile.anchoredPosition = new Vector2 ( listPosX, listPosY );
                        Texture2D objectPreview = RuntimePreviewGenerator.GenerateModelPreview ( objectPrefab.transform, 64, 64, false );
                        Sprite objectPreviewSprite = Sprite.Create ( objectPreview, new Rect ( 0, 0, 64, 64 ), new Vector2 ( 0.5f, 0.5f ) );
                        currentTile.GetComponent<Image> ().overrideSprite = objectPreviewSprite;
                        string objectName = Path.GetFileNameWithoutExtension ( objectsDirFileList [ objectsCounter ] );
                        currentTile.GetComponentInChildren<TextMeshProUGUI> ().SetText ( objectName );
                        listPosX += 4.25F + 20;
                    }
                    else j--;
                    objectsCounter++;
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
        return objectAssetBundle.LoadAsset<GameObject> ( "SpawnedObject" ); 
    }
    void PopulateObjectListGrid ()
    {

    }

}
