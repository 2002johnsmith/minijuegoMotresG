using UnityEngine;

public class EnemigoVertical : MonoBehaviour
{
    public float velocidad = 2f;
    private float limiteSuperior;
    private float limiteInferior;
    private int direccion = 1; 

    void Start()
    {
        limiteSuperior = transform.position.y + 5f;
        limiteInferior = transform.position.y - 5f;
    }

    void Update()
    {
        transform.position += Vector3.up * velocidad * direccion * Time.deltaTime;

        if (transform.position.y >= limiteSuperior || transform.position.y <= limiteInferior)
        {
            direccion *= -1;
        }
    }
}
