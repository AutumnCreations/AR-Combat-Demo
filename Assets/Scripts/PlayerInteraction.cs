using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject placementIndicator = null;

    ARSessionOrigin origin;
    Pose placementPose;
    EventSystem eventSystem;
    

    bool isPlacementValid;

    void Start()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        origin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        //if (isPlacementValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    if (eventSystem.IsPointerOverGameObject())
        //    {
        //    return;
        //    }
        //    PlaceObject();
        //}
    }

    public void PlaceObject(GameObject objectToPlace)
    {
        if (isPlacementValid)
        {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (isPlacementValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        origin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, TrackableType.Planes);

        isPlacementValid = hits.Count > 0;
        if (isPlacementValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}

