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
    private float zPos;
    void Start()
    {
        zPos = transform.position.z;
        cameraTransform = Camera.main.transform;
        previousPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousPos;

        Vector3 newPos = transform.position += delta * effectMultiplier;
        newPos.z = zPos;
        transform.position = newPos;

        previousPos = cameraTransform.position;
    }
}
