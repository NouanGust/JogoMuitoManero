using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("Efeitos")]
    public GameObject EfeitoDano;
    public GameObject EfeitoCura;
    
    [Header("Player")]
    public TextMeshProUGUI vidaPlayerTexto;
    public int vidaAtual;
    public int vidaMax = 10;
    public bool taVivo = true;
    [Header("Inimigo")]
    public TextMeshProUGUI vidaInimigoTexto;
    public int vidaAtualInimigo;
    public int vidaMaxInimigo = 10;
    public bool taVivoInimigo = true;


    private void Awake()
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
        vidaAtual = vidaMax;
        vidaAtualInimigo = vidaMaxInimigo;
        AtualizarUI();
    }


    public void DarDanoInimigo(int valor, Vector3 pos)
    {
        // Primeiro calcula/dar dano
        vidaAtualInimigo -= valor;
        // Verifico se morreu
        if (vidaAtualInimigo <= 0)
        {
            taVivoInimigo = false;
        }
        else
        {
            taVivoInimigo = true;
        }

        Instantiate(EfeitoDano, pos, Quaternion.identity); 

        AtualizarUI();

    }


    public void DarDanoPlayer(int valor)
    {
        // Primeiro calcula/dar dano
        vidaAtual -= valor;
        // Verifico se morreu
        if (vidaAtual <= 0)
        {
            taVivo = false;
        }
        else
        {
            taVivo = true;
        }
        AtualizarUI();

    }

    public void CurarInimigo(int valor)
    {
        if (taVivoInimigo && vidaAtualInimigo != vidaMaxInimigo)
        {
            vidaAtualInimigo += valor;
            if (vidaAtualInimigo > vidaMaxInimigo)
            {
                vidaAtualInimigo = vidaMaxInimigo;
            }

        }

        AtualizarUI();

    }

    public void CurarPlayer(int valor)
    {
        if (taVivo && vidaAtual != vidaMax)
        {
            vidaAtual += valor;
            if(vidaAtual > vidaMax)
            {
                vidaAtual = vidaMax;
            }

        }

        AtualizarUI();
    }

    public void AtualizarUI()
    {
        if (taVivoInimigo)
        {
            // Se sim, atualiza a vida
            vidaInimigoTexto.text = $"Vida: {vidaAtualInimigo}/{vidaMaxInimigo}";
            vidaPlayerTexto.text = $"Vida: {vidaAtual}/{vidaMax}";

        }
        else
        {
            // Se não, Derrota
            vidaInimigoTexto.text = $"Derrotado";
        }

    }



}
