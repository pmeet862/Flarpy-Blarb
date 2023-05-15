using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class pauseBtnScript : MonoBehaviour
{
    public void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

}
