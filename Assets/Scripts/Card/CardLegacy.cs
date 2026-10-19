using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CardLegacy : MonoBehaviour
{
    [Header("Configurações de Hover")]
    public float hoverScaleMultiplier = 1.2f;
    private Vector3 originalScale;

    [Header("Componentes Visuais")]
    private SpriteRenderer spriteRenderer;
    private int originalSortingOrder;

    // Variáveis de controle para o Drag & Drop
    private bool isDragging = false;
    private Vector3 dragOffset;

    void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalSortingOrder = spriteRenderer.sortingOrder;
        }
    }

    void OnMouseEnter()
    {
        if (!isDragging)
        {
            transform.localScale = originalScale * hoverScaleMultiplier;

            if (spriteRenderer != null)
                spriteRenderer.sortingOrder = originalSortingOrder + 10;
        }
    }

    void OnMouseExit()
    {
        if (!isDragging)
        {
            transform.localScale = originalScale;
            if (spriteRenderer != null)
                spriteRenderer.sortingOrder = originalSortingOrder;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;

        dragOffset = transform.position - GetMouseWorldPosition();

        Debug.Log($"Carta {gameObject.name} selecionada/agarrada.");
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + dragOffset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        transform.localScale = originalScale;
        if (spriteRenderer != null)
            spriteRenderer.sortingOrder = originalSortingOrder;

        Debug.Log($"Carta {gameObject.name} solta na mesa na posição {transform.position}.");

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z);

        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}