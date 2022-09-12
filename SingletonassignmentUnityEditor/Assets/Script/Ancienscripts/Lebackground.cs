using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lebackground : MonoBehaviour
{
    public Vector2 parallaxEffectMultiplier;
    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        _lastCameraPosition = _cameraTransform.position;
    }
}
