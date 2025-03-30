using UnityEngine;

public class ColorCHANGE : MonoBehaviour
{
    public SpriteRenderer personaje; // Arrastra el personaje en el Inspector

    public void CambiarColorRojo()
    {
        if (personaje != null)
        {
            personaje.color = Color.red;
        }
    }

    public void CambiarColorVerde()
    {
        if (personaje != null)
        {
            personaje.color = Color.green;
        }
    }

    public void CambiarColorAmarillo()
    {
        if (personaje != null)
        {
            personaje.color = Color.yellow;
        }
    }

    public void CambiarColorAzul()
    {
        if (personaje != null)
        {
            personaje.color = Color.blue;
        }
    }
}
