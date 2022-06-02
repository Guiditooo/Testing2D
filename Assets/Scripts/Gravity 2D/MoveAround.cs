using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;

    private delegate void Movement();

    private Movement whatToDo;

    private void Awake()
    {
        ClampToScreen.JustPassedBorder += StopMoving;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            whatToDo = MoveRight;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            whatToDo = MoveLeft;
        }
        else
        {
            whatToDo = StopMoving;
        }
    }

    private void LateUpdate()
    {
        whatToDo();
    }

    private void OnDestroy()
    {
        ClampToScreen.JustPassedBorder -= StopMoving;
    }

    void MoveLeft()
    {
        transform.RotateAround(target.position, transform.forward, speed * Time.deltaTime);
    }
    void MoveRight()
    {
        transform.RotateAround(target.position, transform.forward, - speed * Time.deltaTime);
    }
    void StopMoving()
    {
        
    }

}
