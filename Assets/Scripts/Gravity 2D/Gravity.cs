using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Transform referenceTransform;
    [SerializeField] private Vector3 reference;
    [SerializeField] private bool useCameraCenterAsGravityCenter = true;

    [SerializeField] private float gravityForce;

    private float gravityAtenuation = 0.1f;

    private PlayerPhysics playerPhysics;

    private Vector3 vectorUp;
    private void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }
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

        playerPhysics.Velocity -= gravityForce * gravityAtenuation;

    }

    private void Update()
    {
        vectorUp = transform.position - reference;
        vectorUp.Normalize();
        transform.up = vectorUp;
        playerPhysics.Velocity -= gravityForce * gravityAtenuation;
    }
}
