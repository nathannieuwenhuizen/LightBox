using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    private Vector3 previousPos;
    private Transform cameraTransform;

    [Range(-1,1)]
    [SerializeField]
    private float effectMultiplier = 0;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousPos;
        transform.position += delta * effectMultiplier;
        previousPos = cameraTransform.position;
    }
}
