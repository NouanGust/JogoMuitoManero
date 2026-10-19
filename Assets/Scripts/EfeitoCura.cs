using UnityEngine;

public class EfeitoCura : CartaEfeito
{
    // Construtor

    public EfeitoCura(int valor)
    {
        this.valor = valor;
    }


    public override void AplicarEfeito(Vector3 pos)
    {
        // Avisar o GameManger para curar o jogador
        GameManager.Instance.CurarPlayer(valor);
        Debug.Log($"Curou o jogador em {valor}");
    }
}
