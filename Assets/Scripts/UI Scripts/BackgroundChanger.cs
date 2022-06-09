using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Color32 def;
    [SerializeField] private Color32 tar;

    [SerializeField] private Image image;

    [SerializeField] private TMP_Text bottomMessage;

    private bool buttonClicked = false;

    private void Start()
    {
        def = image.color;
        buttonClicked = false;
    }

    public void ChangeBackgroundColor()
    {
        buttonClicked = !buttonClicked;
        image.color = buttonClicked ? tar : def;
        Debug.Log(image.color);
    }

    public void ShowMessage()
    {
        bottomMessage.enabled = true;
    }
    public void HideMessage()
    {
        bottomMessage.enabled = false;
    }

}
