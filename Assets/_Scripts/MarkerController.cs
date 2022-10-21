using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerController : MonoBehaviour
{
    public GameObject markerPrefab;
    [CanBeNull] public ARPlane CurrentPlane;
    public GameObject _markerGO;

    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private Camera _cameraMain;

    void Start()
    {
        GameObject ArSessionOrigin = GameObject.Find("AR Session Origin");
        ARRaycastManager = ArSessionOrigin.GetComponent<ARRaycastManager>();
        ARPlaneManager = ArSessionOrigin.GetComponent<ARPlaneManager>();
        _cameraMain = Camera.main;
        _markerGO = Instantiate(markerPrefab);
        CurrentPlane = null;
    }
    
    void Update()
    {
        _markerGO.SetActive(false);
        Vector3 centerPos = _cameraMain.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(centerPos, hits, TrackableType.Planes);
        
        ARRaycastHit? hit = null;
        if (hits.Count > 0)
        {
            hit = hits[0];
        }

        if (hit.HasValue)
        {
            _markerGO.transform.position = hit.Value.pose.position;
            CurrentPlane = ARPlaneManager.GetPlane(hit.Value.trackableId);
            _markerGO.SetActive(true);
        }
    }
}
