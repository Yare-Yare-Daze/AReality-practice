using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public List<GameObject> ControllingGameObjects;
    
    private GameObject _debugPanel;
    private GameObject _carSpawner;
    private GameObject _trackImage;
    private bool _isCarSpawning = false;
    private bool _isTrackingImage = false;
    private bool _isDebugging = false;

    private void Awake()
    {
        foreach (var cGO in ControllingGameObjects)
        {
            cGO.SetActive(false);
        }
    }

    private void Start()
    {
        foreach (var cGO in ControllingGameObjects)
        {
            if (cGO.gameObject.name == "Car Spawner")
            {
                _carSpawner = cGO;
            }
            else if (cGO.gameObject.name == "TrackImage")
            {
                _trackImage = cGO;
            }
            else if (cGO.gameObject.name == "DebugPanel")
            {
                _debugPanel = cGO;
            }
        }
    }

    public void OnClickCarDriverButton()
    {
        /*if (_carSpawner == null) return;

        if (!_isCarSpawning)
        {
            _carSpawner.SetActive(true);
            _isCarSpawning = true;
        }
        else
        {
            _carSpawner.SetActive(false);
            _isCarSpawning = false;
        }*/
        
        ChangeActiveOnClick(ref _isCarSpawning, _carSpawner);
        
    }
    
    public void OnClickTrackImageButton()
    {
        /*if (_trackImage == null) return;

        if (!_isTrackingImage)
        {
            _trackImage.SetActive(true);
            _isTrackingImage = true;
        }
        else
        {
            _trackImage.SetActive(false);
            _isTrackingImage = false;
        }*/
        
        ChangeActiveOnClick(ref _isTrackingImage, _trackImage);
    }
    
    public void OnClickDebugButton()
    {
        /*if (_debugPanel == null) return;

        if (!_isDebugging)
        {
            _debugPanel.SetActive(true);
            _isDebugging = true;
        }
        else
        {
            _debugPanel.SetActive(true);
            _isDebugging = false;
        }*/
        
        ChangeActiveOnClick(ref _isDebugging, _debugPanel);
    }

    private void ChangeActiveOnClick(ref bool isSomething, GameObject go)
    {
        if (go == null) return;
        
        
        
        if (!isSomething)
        {
            go.SetActive(true);
            isSomething = true;
        }
        else
        {
            go.SetActive(false);
            isSomething = false;
        }
        
        Debug.Log(go.name + " is " + go.activeInHierarchy);
        Debug.Log("isSomething = " + isSomething);
    }
}
