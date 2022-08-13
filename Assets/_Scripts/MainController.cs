using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public List<GameObject> ControllingGameObjects;

    private void Awake()
    {
        foreach (var cGO in ControllingGameObjects)
        {
            cGO.SetActive(false);
        }
    }

    public void OnClickCarDriverButton()
    {
        if (ControllingGameObjects == null) return;

        ControllingGameObjects[0].SetActive(true);
    }
    
    public void OnClickTrackImageButton()
    {
        if (ControllingGameObjects == null) return;
        
        ControllingGameObjects[1].SetActive(true);
    }

    public void OnClickClearButton()
    {
        if (ControllingGameObjects == null) return;

        foreach (var cGo in ControllingGameObjects)
        {
            cGo.SetActive(false);
        }
    }

    
}
