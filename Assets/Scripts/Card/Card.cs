using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool selecionada = false;

    public Vector3 startPosition;
    private Vector3 clickOffset;


    private BoxCollider2D bc;

    [Header("Configurações de suavização")]
    public float suaviVel = 3f;
    public Vector3 originalScale;
    public Vector3 targetScale;
    public float hoverScaleMultiplier = 1.2f;

    public Vector3 suavVel;

    // smoothTime -> camelCase
    // smooth_time -> snake_case
    // SmoothTime -> PascalCase

    public float smoothTime = 1.5f;
    public float maxSpeed = 2f;

    [Header("Configurações dos efeitos")]
    DamageEffect dano = new DamageEffect();

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;

        bc = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        // Vector3.Lerp(valorInicial, valorAlvo, velocidade)
        //transform.localScale = Vector3.Lerp(transform.localScale, targetScale, suaviVel * Time.deltaTime);

        // Vector3.SmoothDamp(valorInicial, valorAlvo, ref, tempo, velocidadeMax)
        transform.localScale = Vector3.SmoothDamp(
            transform.localScale, 
            targetScale, 
            ref suavVel, 
            smoothTime, 
            maxSpeed
        );
        

    }

    // Método da Interface pointer.
    // Nos parenteses, o da esquerda é sempre o TIPO e o da direita é sempre a variavel
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Passei o mouse na carta!");
        targetScale = originalScale * hoverScaleMultiplier; // Magic number / Hardcoded 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        selecionada = !selecionada;

        if (selecionada)
        {
            //Debug.Log("Selecionada");
            transform.localPosition += new Vector3(0, 0.3f, 0);
        } else
        {
            //Debug.Log("Carta Desmarcada");
            transform.localPosition -= new Vector3(0, 0.3f, 0);
        }
    }

    // -----------------------
    // Drag e Drop
    // -----------------------



    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        bc.enabled = false;

        Vector3 mouseWorldPos = GetWorldPosition(eventData.position);
        clickOffset = transform.position - mouseWorldPos;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWorldPos = GetWorldPosition(eventData.position);
        transform.position = mouseWorldPos + clickOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool jogadaValida = false;
        if (!jogadaValida)
        {
            transform.position = startPosition;
        }

        bc.enabled = true;
        dano.Executar();
    }

    // Aux

    private Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Vector3 point = new Vector3(screenPosition.x, screenPosition.y, Mathf.Abs(Camera.main.transform.position.z));
        return Camera.main.ScreenToWorldPoint(point);
    }

    public void SetNewStartingPosition(Vector3 newPosition)
    {
        startPosition = newPosition;
    }
}
