using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    SpriteRenderer spriteQuadrado;
    Color corOriginal;
    void Start()
    {
        spriteQuadrado = GetComponent<SpriteRenderer>();
        corOriginal = spriteQuadrado.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter.name);
        //eventData.pointerEnter.GetComponent<SpriteRenderer>();
        spriteQuadrado.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteQuadrado.color = corOriginal;
    }
}
