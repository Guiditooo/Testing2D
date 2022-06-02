using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityForce;
    [SerializeField] private Transform targetTransform;

    private Vector3 newUp;
    private void Start()
    {
        GetNewVectorUp();
    }

    private void Update()
    {
        GetNewVectorUp();
    }

    void LateUpdate()
    {
        transform.up = newUp;
        transform.position -= transform.up.normalized * gravityForce * Time.deltaTime;
    }

    void GetNewVectorUp()
    {
        newUp = transform.position - targetTransform.position;
        newUp.Normalize();
    }

}
