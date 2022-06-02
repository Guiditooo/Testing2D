using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClampToScreen : MonoBehaviour
{
    private SpriteRenderer sr;
    private static Vector3 screenSize;
    private static Vector3 screenSizeVP;

    private List<Vector3> borders = new List<Vector3>();

    public static Action JustPassedBorder;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        CalculateScreenSizes();
    }

    private void Update()
    {
        CalculateBorders();
    }

    private void LateUpdate()
    {
        borders.Clear();
    }

    void CalculateScreenSizes()
    {
        screenSize = new Vector3(Screen.width, Screen.height, 0);
        screenSizeVP = Camera.main.ScreenToViewportPoint(screenSize);
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
            if (border.x < 0  || border.x > 1)
            {
                JustPassedBorder();
            }
        }
    }

}
