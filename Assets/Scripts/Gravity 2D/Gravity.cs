using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityForce = 1.0f;
    [SerializeField] private Transform targetTransform = null;

    private Vector3 newUp = Vector3.zero;
    private void Start()
    {
        GetNewVectorUp();
    }

    private void Update()
    {
        GetNewVectorUp();
    }

    private void GetNewVectorUp() //Consigo la direccion del vector up.
    {
        newUp = transform.position - targetTransform.position;
        newUp.Normalize();
    }

    public void GetAttracted() 
    {
        transform.up = newUp; // Hago que el vector up de la nave sea igual al obtenido restando las posiciones.
        transform.position -= transform.up.normalized * gravityForce * Time.deltaTime; //Resto en el sentido del vector up
    }

}
