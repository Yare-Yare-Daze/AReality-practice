/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleBehaviour : MonoBehaviour
{
    public GameObject Child;
    public ARRaycastManager ARRaycastManager;
    public ARPlaneManager ARPlaneManager;
    

    // Start is called before the first frame update
    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
        ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Camera.main == null)
        {
            Debug.Log("Camera null");
        }
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        var hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);
        
        ARRaycastHit? hit = null;
        if (hits.Count > 0)
        {
            hit = hits[0];
        }

        if (hit.HasValue)
        {
            transform.position = hit.Value.pose.position;
            Child.SetActive(true);
        }
        else
        {
            Child.SetActive(false);
        }
        
    }
}
