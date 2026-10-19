using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [Header("Informações da carta")]
    public Vector3 startPos;
    BoxCollider2D colisor;


    [Header("Carta")]
    public int dano = 3;
    public EfeitoDano efeito = new EfeitoDano(3);


    void Start()
    {
        colisor = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        
    }


    // ====================================
    // Hover e click
    // ====================================

   
    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log($"Posição: {PegaPosicaoMundo(eventData.position)}");

    }


    // ====================================
    // Drag e Drop
    // ====================================
        
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Pegar a posição da minha carta
        startPos = transform.position;
        // Desabilidar a colisão da carta
        colisor.enabled = false;

        // Pegar a posição do mouse ???

    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 ponto = PegaPosicaoMundo(eventData.position);
        // atualizar a posição da carta com a posição do mouse
        transform.position = ponto;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool jogadaValida = true;    
        // Jogada é valida?
        if (jogadaValida)
        {
            // Se sim, colocar a carta na posição certa
            // Pegar a posição atual do mouse ou do objeto e colocar a carta lá

            efeito.AplicarEfeito(transform.position);
            TurnManager.Instance.TurnoInimigo();


        }
        else
        {
            // Senão, voltar a carta para a "mão" -> posição inicial
            transform.position = startPos;
        }

        // Habilidar a colisão da carta
        colisor.enabled = true;
    }

    // ====================================
    // Aux
    // ====================================

    private Vector3 PegaPosicaoMundo(Vector2 posicaoTela)
    {
        Vector3 ponto = new Vector3(posicaoTela.x, posicaoTela.y, Mathf.Abs(Camera.main.transform.position.z));
        return Camera.main.ScreenToWorldPoint(ponto);
    }
}
