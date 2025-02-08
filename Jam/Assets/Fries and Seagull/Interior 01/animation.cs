using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text txt;
    public Image img;
    public void OnPointerEnter(PointerEventData eventData)
    {
        txt.color = Color.black;
        img.enabled = true;
        img.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        txt.color = Color.white;
        img.enabled = false;
    }
}
