using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    enum ECurrentState
    {
        none = 0,
        carSpawning,
        trackingImage,
        /*debugging,*/
        createObjectOnPlane
    }
    
    public List<GameObject> controllingGameObjects;
    public GameObject debugGO;

    private ECurrentState _state = ECurrentState.none;

    private void Awake()
    {
        ClearState();
        
        DebugPanel.debugText += $"{_state}\n";
    }

    private void Start()
    {
        
    }

    public void OnClickCarDriverButton()
    {
        if (_state != ECurrentState.carSpawning)
        {
            ClearState();
            GameObject tempGO = controllingGameObjects.Find(x => x.name.Contains("Car Spawner"));
            tempGO.SetActive(true);
            _state = ECurrentState.carSpawning;
            
            DebugPanel.debugText += $"{_state}\n";
        }
    }
    
    public void OnClickTrackImageButton()
    {
        if (_state != ECurrentState.trackingImage)
        {
            ClearState();
            GameObject tempGO = controllingGameObjects.Find(x => x.name.Contains("TrackImage"));
            tempGO.SetActive(true);
            _state = ECurrentState.trackingImage;
            
            DebugPanel.debugText += $"{_state}\n";
        }
    }
    
    public void OnClickDebugButton()
    {
        if (!debugGO.activeSelf)
        {
            debugGO.SetActive(true);
        }
        else
        {
            debugGO.SetActive(false);
        }

        /*if (_state != ECurrentState.debugging)
        {
            ClearState();
            GameObject tempGO = controllingGameObjects.Find(x => x.name.Contains("DebugPanel"));
            tempGO.SetActive(true);
            _state = ECurrentState.debugging;
            
            DebugPanel.debugText += _state;
        }*/
    }

    public void OnClickCreateAndMoveButton()
    {
        if (_state != ECurrentState.createObjectOnPlane)
        {
            ClearState();
            GameObject tempGO = controllingGameObjects.Find(x => x.name.Contains("CreateAndMoveObjects"));
            tempGO.SetActive(true);
            _state = ECurrentState.createObjectOnPlane;
            
            DebugPanel.debugText += $"{_state}\n";
        }
    }
    
    public void OnClickClearButton()
    {
        ClearState();
        
        DebugPanel.debugText += $"{_state}\n";
    }

    private void ClearState()
    {
        foreach (var cGO in controllingGameObjects)
        {
            cGO.SetActive(false);
        }

        _state = ECurrentState.none;
        
    }
}
