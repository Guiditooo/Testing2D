using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float Velocity { get; set; }

    public float velocity;

    private void LateUpdate()
    {
        velocity = Velocity;
        ApplyPhysics();
    }

    private void ApplyPhysics()
    {
        transform.position += transform.up.normalized * Velocity * Time.deltaTime; //Aplica fuerza al eje up. Sea para subir, o bajar. 
    }

}
