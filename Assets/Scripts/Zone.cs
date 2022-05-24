using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zone : MonoBehaviour
{
    [SerializeField] private Color stayColor;
    //[SerializeField] private Color ExitColor;


    public static Action<Color32> OnRockZoneEnter;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player") OnRockZoneEnter(stayColor);
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player") OnRockZoneEnter(ExitColor);
    }
    */
}
