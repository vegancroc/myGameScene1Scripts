using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    #endregion

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }
    #region Functions
    private void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
    #endregion

}
