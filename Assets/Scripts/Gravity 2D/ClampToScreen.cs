using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClampToScreen : MonoBehaviour
{
    private SpriteRenderer sr;
    private static Vector3 screenSize;
    private static Vector3 screenSizeVP;

    private List<Vector3> borders = new List<Vector3>(); //Lista de Puntos exteriores del sprite

    public static Action JustPassedBorder;
    public static Action JustInsideBorders;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CalculateBorders();
        CheckBorderCollision();
    }

    private void LateUpdate()
    {
        borders.Clear();
    }

    void CalculateBorders()
    {
        borders.Add(Camera.main.WorldToViewportPoint(new Vector3(transform.position.x - sr.bounds.extents.x, transform.position.y - sr.bounds.extents.y, 0)));
        borders.Add(Camera.main.WorldToViewportPoint(new Vector3(transform.position.x + sr.bounds.extents.x, transform.position.y - sr.bounds.extents.y, 0)));
        borders.Add(Camera.main.WorldToViewportPoint(new Vector3(transform.position.x - sr.bounds.extents.x, transform.position.y + sr.bounds.extents.y, 0)));
        borders.Add(Camera.main.WorldToViewportPoint(new Vector3(transform.position.x + sr.bounds.extents.x, transform.position.y + sr.bounds.extents.y, 0)));
    }

    void CheckBorderCollision()
    {
        foreach (Vector3 border in borders)
        {
            if (border.x < 0 || border.x > 1 || border.y < 0 || border.y > 1) //Si algun punto esta fuera de la pantalla
            {
                Debug.Log("Salgo de la pantalla.");
                JustPassedBorder?.Invoke(); //Cancelo el movimiento
                return;
            }
            else
            {
                JustInsideBorders?.Invoke(); //Permito el movimiento
            }

        }
    }

}
