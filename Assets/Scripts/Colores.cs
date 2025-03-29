using UnityEngine;

public class Colores : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] colores = { Color.red, Color.blue, Color.yellow, Color.green };

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colores[Random.Range(0, colores.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
