using UnityEngine;

public class EnemigoHorizontal : MonoBehaviour
{
    public float velocidad = 2f;
    private float limiteDerecho;
    private float limiteIzquierdo;
    private int direccion = 1; 

    void Start()
    {
        limiteDerecho = transform.position.x + 5f;
        limiteIzquierdo = transform.position.x - 5f;
    }

    void Update()
    {
        transform.position += Vector3.right * velocidad * direccion * Time.deltaTime;

        if (transform.position.x >= limiteDerecho || transform.position.x <= limiteIzquierdo)
        {
            direccion *= -1; 
        }
    }
}
