using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{
    [SerializeField] private float propulsionForce = 5;
    public void Propulsate()
    {
        transform.position += transform.up * propulsionForce * Time.deltaTime;
    }

}
