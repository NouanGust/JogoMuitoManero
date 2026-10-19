using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [Header("Config da mesa")]
    public int maxCardInSlot = 10;
    private int currentCards = 0;

    private SpriteRenderer sr;
    private Color originalColor;
    private BoxCollider2D dropCollider;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        dropCollider = GetComponent<BoxCollider2D>();
        
        if (sr != null)
        {
            originalColor = sr.color;
        }
    }


    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sr.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sr.color = originalColor;
    }

    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log($"{eventData.pointerDrag.name} foi solta na Zona de Drop");

        if (sr != null) sr.color = originalColor;

        if (currentCards >= maxCardInSlot)
        {
            Debug.Log("Slot cheio! A carta volta para mão.");
            return;
        }

        GameObject carta = eventData.pointerDrag;
        if(carta != null)
        {
            Card cartaScript = carta.GetComponent<Card>();

            if (carta != null)
            {
                Debug.Log($"A carta {carta.name} foi jogada na mesa.");
                carta.transform.SetParent(this.transform, false);
                carta.transform.localPosition = new Vector3(0, 0, -0.1f);
                Vector2 areaSize = dropCollider.bounds.size;

                SpriteRenderer cartaSprite = carta.GetComponent<SpriteRenderer>();

                Vector2 cartaTamanhoOriginal = cartaSprite.sprite.bounds.size;

                float scaleX = areaSize.x / cartaTamanhoOriginal.x;
                float scaleY = areaSize.y / cartaTamanhoOriginal.y;

                float finalScale = Mathf.Min(scaleX, scaleY);
                carta.transform.localScale = new Vector3(finalScale, finalScale, 1f);


                cartaScript.SetNewStartingPosition(carta.transform.position);

                currentCards++;


                // Aplicar efeito
            }
        }



    }
}
