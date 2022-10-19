using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateAndMoveObjectOnPlane : MonoBehaviour
{
    [SerializeField] private GameObject placedObject;
    [SerializeField] private GameObject placedPrefab;
    [SerializeField] private bool holdObject = false;
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager _arRaycastManager;
    [SerializeField] private List<ARRaycastHit> _arRaycastHits = new List<ARRaycastHit>();
    
    // Start is called before the first frame update
    void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(_touch.position);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.transform.tag.Equals("tracking"))
                    {
                        holdObject = true;
                    }
                }
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                holdObject = false;
            }
            
            Debug.Log("holdObject = " + holdObject);

            if (_arRaycastManager.Raycast(_touch.position, _arRaycastHits, TrackableType.Planes))
            {
                Pose hitPose = _arRaycastHits[0].pose;
                
                foreach (var arRaycastHit in _arRaycastHits)
                {
                    if (placedObject == null)
                    {
                        placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        if (holdObject)
                        {
                            placedObject.transform.position = hitPose.position;
                            placedObject.transform.rotation = hitPose.rotation;
                        }
                    }
                }
            }
        }
    }
}
