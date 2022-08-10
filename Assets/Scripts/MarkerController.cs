using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerController : MonoBehaviour
{
    public GameObject markerPrefab;
    public ARRaycastManager ARRaycastManager;

    private Camera _cameraMain;
    private GameObject _markerGO;
    
    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        _cameraMain = Camera.main;
        _markerGO = Instantiate(markerPrefab);
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
            _markerGO.SetActive(true);
        }
    }
}
