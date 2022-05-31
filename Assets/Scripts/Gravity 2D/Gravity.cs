using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Transform referenceTransform;
    [SerializeField] private Vector3 reference;
    [SerializeField] private bool useCameraCenterAsGravityCenter = true;

    private Vector3 vectorUp;
    private void Start()
    {
        if (useCameraCenterAsGravityCenter || referenceTransform == null)
        {
            reference = Vector3.zero;
        }
        else
        {
            reference = referenceTransform.position;
        }

        vectorUp = transform.position - reference;
        vectorUp.Normalize();

    }

    private void Update()
    {
        vectorUp = transform.position - reference;
        vectorUp.Normalize();
    }

    private void LateUpdate()
    {
        transform.up = vectorUp;
    }

}
