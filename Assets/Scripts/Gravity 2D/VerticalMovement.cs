using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float verticalForce;

    [SerializeField] private float velocity;
    
    [SerializeField] private float maxAcceleration; 



    private void Start()
    {
        velocity = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (velocity + verticalForce > maxAcceleration) return;
            velocity += verticalForce;
        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
    }
    private void LateUpdate()
    {
        transform.position += transform.up.normalized * velocity * Time.deltaTime;
    }

}
