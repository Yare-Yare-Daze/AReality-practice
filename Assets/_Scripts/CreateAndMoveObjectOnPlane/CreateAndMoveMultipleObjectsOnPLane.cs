using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateAndMoveMultipleObjectsOnPLane : MonoBehaviour
{
    [SerializeField] private GameObject placedPrefab;

    private List<GameObject> placedObjects = new List<GameObject>();
    private int choosenObjectIndex = 0;
    private bool holdObject = false;

    private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> _arRaycastHits = new List<ARRaycastHit>();
    
    void Start()
    {
        _arRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
    }

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
                        choosenObjectIndex = raycastHit.transform.gameObject.GetComponent<TrackableObjectOnPlane>().index;
                    }
                }
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                holdObject = false;
            }

            //Debug.Log("holdObject = " + holdObject);

            if (_arRaycastManager.Raycast(_touch.position, _arRaycastHits, TrackableType.Planes))
            {
                foreach (var arRaycastHit in _arRaycastHits)
                {
                    Pose hitPose = arRaycastHit.pose;

                    if (holdObject)
                    {
                        if (_touch.phase == TouchPhase.Moved)
                        {
                            placedObjects[choosenObjectIndex].transform.position = hitPose.position;
                            placedObjects[choosenObjectIndex].transform.rotation = hitPose.rotation;
                        }
                    }
                    else
                    {
                        if (_touch.phase == TouchPhase.Began)
                        {
                            GameObject tempObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                            tempObject.GetComponent<Renderer>().material.color =
                                new Color(Random.value, Random.value, Random.value, 1f);
                            placedObjects.Add(tempObject);
                            placedObjects[^1].GetComponent<TrackableObjectOnPlane>().index = placedObjects.Count - 1;
                        }
                    }
                }
            }
        }
    }
}
