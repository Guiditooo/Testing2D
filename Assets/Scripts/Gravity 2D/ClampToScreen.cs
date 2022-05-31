using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    private SpriteRenderer sr;
    private static Vector3 screenSize;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        screenSize = new Vector3(Screen.width, Screen.height, 0);
    }

    private void Update()
    {

        Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);

        Debug.Log("Screen Position> "+posInScreen);
        Debug.Log("Screen Size> "+screenSize);

    }

    

}
