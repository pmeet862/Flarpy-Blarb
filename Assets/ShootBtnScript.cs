using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShootBtnScript : MonoBehaviour
{
    // private Transform postionToSet;
    private Vector2 pos;
    private Vector3 NewPos;
    private float posx, posy;

    private RectTransform btnPos;
    private void OnEnable()
    {
        btnPos = gameObject.GetComponent<RectTransform>();
        pos.x = PlayerPrefs.GetFloat("PosX");
        pos.y = PlayerPrefs.GetFloat("PosY");
        // Debug.Log("Position" + pos);

        if (pos != null)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(btnPos, pos, new Camera(), out NewPos);
            transform.position = NewPos;
        }
        else
        {
            transform.position = transform.position;
        }
    }
}
