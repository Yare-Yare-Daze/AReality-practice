using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubeMoveOnPlane : MonoBehaviour
{
    public ARPlaneManager ARPlaneManager;
    public ARRaycastManager ARRaycastManager;
    public GameObject GOPrafab;

    private Vector3 _centerScreen;
    private ARPlane _currentARPlane;
    [CanBeNull] private GameObject _newGameObject;

    private void Start()
    {
        _centerScreen = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    }

    private void Update()
    {
        if(Input.touchCount == 0) return;
        
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinBounds);

        ARRaycastHit? hit = null;
        
        if (hits.Count > 0)
        {
            hit = hits[0];
            _currentARPlane = ARPlaneManager.GetPlane(hit.Value.trackableId);
            
            /*if (_newGameObject == null)
            {
                _newGameObject = Instantiate(GOPrafab, _currentARPlane.normal, Quaternion.identity);
            }*/
        }
    }
}
