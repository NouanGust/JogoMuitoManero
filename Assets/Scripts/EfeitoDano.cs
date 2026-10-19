using UnityEngine;

public class EfeitoDano : CartaEfeito
{


    void Awake()
    {
        tipo = Tipo.Dano;
    }

    // Construtor 
    public EfeitoDano(int valor)
    {
        this.valor = valor;
    }

    public override void AplicarEfeito(Vector3 pos)
    {
        if (tipo == Tipo.Dano)
        {
            // Avise o GameManager para dar dano no inimigo
            GameManager.Instance.DarDanoInimigo(valor, pos);
            Debug.Log($"Inimigo tomou {valor} dano!");

        } else if (tipo == Tipo.Cura)
        {
            GameManager.Instance.CurarPlayer(valor);
        }
    }

}
