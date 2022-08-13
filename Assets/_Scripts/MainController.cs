using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject CarSpawner;

    private void Awake()
    {
        CarSpawner.SetActive(false);
    }

    public void OnClickCarDriverButton()
    {
        if (CarSpawner == null) return;

        CarSpawner.SetActive(true);
    }

    public void OnClickClearButton()
    {
        if (CarSpawner == null) return;
        
        CarSpawner.SetActive(false);
    }
}
