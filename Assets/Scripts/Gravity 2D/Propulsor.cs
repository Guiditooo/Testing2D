using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{

    [SerializeField] private float propulsionForce;

    private bool mayMove = false;

    private void Update()
    {
        mayMove = Input.GetKey(KeyCode.Space);
    }
    private void LateUpdate()
    {
        if (mayMove)
        {
            transform.Translate(transform.up * propulsionForce * Time.deltaTime);
        }
    }
}
