using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float verticalForce;    
    [SerializeField] [Range(1,4)] private float maxAcceleration;

    [SerializeField] private Transform referenceTransform;

    [SerializeField] private float velocity;

    [SerializeField] private float rotateSpeed;

    private PlayerPhysics playerPhysics;

    private void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (playerPhysics.Velocity + verticalForce > maxAcceleration) return;
            playerPhysics.Velocity += verticalForce;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(referenceTransform.position, transform.forward, -rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(referenceTransform.position, transform.forward, rotateSpeed);
        }
        
    }

}
