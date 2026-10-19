using System.Collections;
using UnityEditor;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    // Singleton
    public static TurnManager Instance;

    // Definir turnos
    public enum Turno
    {
        Player,
        Inimigo
    }
    public Turno turnoAtual = Turno.Player;

    // Definir pausa entre turnos (pensamento do oponente)
    public float pausaEntreTurnos = 2.5f;

    public GameManager gameManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        TurnoPlayer();
    }

    // Turno do player
    public void TurnoPlayer()
    {
        turnoAtual = Turno.Player;
        Debug.Log("Turno do Player");
    }

    // Turno do inimigo

    public void TurnoInimigo()
    {
        // Identificar o turno
        turnoAtual = Turno.Inimigo;
        Debug.Log("Turno do Inimigo");

        StartCoroutine(JogadaInimigo());

    }

    IEnumerator JogadaInimigo()
    {
        yield return new WaitForSeconds(pausaEntreTurnos);
        // Escolher a jogada (ataque ou defesa)
        // Se vida menor que 5 = defesa
        if (gameManager.vidaAtualInimigo <= 5)
        {
            Debug.Log("Prefiro me defender!");
        // Se vida maior que 5 = ataque
        } else if (gameManager.vidaAtualInimigo > 5)
        {
            Debug.Log("Prefiro atacar!");
        }

        // Executar a jogada

        // Esperar o resultado
        yield return new WaitForSeconds(0.5f);

        // Verificar se ganhou
        if (gameManager.taVivo == false)
        {
            Debug.Log("Player foi derrotado!");
        } else if (gameManager.taVivo == true)
        {
            Debug.Log("Player tá vivo, próximo turno!");
        }
        // passar a vez
        TurnoPlayer();
    }


    // Aux



}
