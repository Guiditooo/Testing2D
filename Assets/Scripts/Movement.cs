using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Sprite spriteUp;
    [SerializeField] private Sprite spriteDown;
    [SerializeField] private Sprite spriteLeft;
    [SerializeField] private Sprite spriteRight;

    private Color32 defaultColor = Color.white;

    [SerializeField] private float speed;

    [SerializeField] private float blinkFrenquency = 1;
    [SerializeField] private int immuneTime;

    [SerializeField] private bool isReceivingDamage;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Zone.OnRockZoneEnter += ChangeColor;
    }
    private void Start()
    {
        isReceivingDamage = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed);
            if (sr.sprite != spriteUp) sr.sprite = spriteUp;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed);
            if (sr.sprite != spriteDown) sr.sprite = spriteDown;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
            if (sr.sprite != spriteLeft) sr.sprite = spriteLeft;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
            if (sr.sprite != spriteRight) sr.sprite = spriteRight;
        }
    }
    void ChangeColor(Color32 newColor)
    {
       if(!isReceivingDamage)
        {
            StartCoroutine(Blink(immuneTime, defaultColor, newColor));   
        }
    }
    private void OnDestroy()
    {
        Zone.OnRockZoneEnter -= ChangeColor;
    }

    IEnumerator Blink(int timeInSeconds,Color32 normalColor, Color32 blinkColor)
    {

        bool blinked = false;
        float timer = 0;
        float localTimer = 0;

        isReceivingDamage = true;
        while (timer < timeInSeconds)
        {
            timer += Time.deltaTime;
            localTimer += Time.deltaTime;
            if (localTimer > blinkFrenquency/2)
            {
                localTimer = 0;
                blinked = !blinked;
            }
            sr.color = blinked ? blinkColor : normalColor;
            yield return null;
        }
        isReceivingDamage = false;
        sr.color = normalColor;
    }

}
