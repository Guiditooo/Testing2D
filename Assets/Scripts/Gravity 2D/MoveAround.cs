using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField] private float speed = 75;
    [SerializeField] private Transform target = null;

    private Gravity gravity = default;
    private Propulsor propulsor = default;

    private delegate void Movement();
    private Movement whatToDo = null; //Plan de accion del player

    private bool shouldMove = true; 
    private void Awake()
    {
        gravity = GetComponent<Gravity>();
        propulsor = GetComponent<Propulsor>();

        ClampToScreen.JustPassedBorder += DisallowMovement; //Impedir que haya inputs
        ClampToScreen.JustInsideBorders += AllowMovement; //Permitir que haya inputs
    }
    private void Start()
    {
        shouldMove = true;
    }
    private void Update()
    {
        whatToDo = gravity.GetAttracted; //La gravedad siempre va a afectar al player, habiendo o no inputs
        //Va a igualarse a la gravedad, porque asi se resetea la lista de cosas para hacer

        if (!shouldMove) return; //Si no se pueden hacer inputs, que no siga checkeando el update

        if (Input.GetKey(KeyCode.Space))
        {
            whatToDo += propulsor.Propulsate; //Gravedad + Propulsar
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            whatToDo += MoveRight; //Gravedad + Rotar a la derecha
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            whatToDo += MoveLeft; //Gravedad + Rotar a la izquierda
        }
    }

    private void LateUpdate()
    {
        whatToDo(); //Realiza todos los movimientos juntos
    }

    private void OnDestroy()
    {
        ClampToScreen.JustPassedBorder -= DisallowMovement; //No quiero que siga suscripto despues de que se destruye
        ClampToScreen.JustInsideBorders -= AllowMovement; //No quiero que siga suscripto despues de que se destruye
    }

    void MoveLeft()
    {
        transform.RotateAround(target.position, transform.forward, speed * Time.deltaTime); //Muevo desde el punto de referencia a la izquierda
    }
    void MoveRight()
    {
        transform.RotateAround(target.position, transform.forward, - speed * Time.deltaTime); //idem MoveLeft, pero a la derecha
    }
    void DisallowMovement()
    {
        shouldMove = false; //Impedira el movimiento
    }
    void AllowMovement()
    {
        shouldMove = true; //Permitira el movimiento
    }

}
