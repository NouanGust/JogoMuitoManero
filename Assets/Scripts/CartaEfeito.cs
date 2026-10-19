using UnityEngine;

public abstract class CartaEfeito
{

    public enum Tipo
    {
        Dano,
        Cura,

    }


    public int valor;
    public Tipo tipo;

    public abstract void AplicarEfeito(Vector3 pos);



}
