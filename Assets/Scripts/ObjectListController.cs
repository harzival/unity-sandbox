using System.Collections;
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
