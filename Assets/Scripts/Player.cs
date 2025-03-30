using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody2D rgb2D;
    public float vida = 10;
    [SerializeField] private TMP_Text vidaTexto; // Texto en pantalla para mostrar la vida


    [Header("Salto")]
    [SerializeField] private float jumpforce;
    [SerializeField] private int countJumps;
    [SerializeField] private int maxjumps;
    [SerializeField] private Transform origin;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerinteraction;
    [SerializeField] private Color conCollision = Color.green;
    [SerializeField] private Color sinCollision = Color.red;

    [SerializeField] private SpriteRenderer spriteRenderer;
    public Color[] colores = new Color[4];
    private int colorIndex = 0;
    private bool enColision = false; // Variable para controlar si está colisionando

    float _direction = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colores[0] = Color.red;
        colores[1] = Color.blue;
        colores[2] = Color.yellow;
        colores[3] = Color.green;
        spriteRenderer.color = colores[colorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && countJumps < maxjumps)
        {
            rgb2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            countJumps++;
        }
        if (!enColision)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) CambiarColor(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) CambiarColor(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) CambiarColor(2);
            if (Input.GetKeyDown(KeyCode.Alpha4)) CambiarColor(3);
        }
        if (Input.GetMouseButtonDown(0))
        {
            CambiarColor();
        }
    }
    private void FixedUpdate()
    {
        rgb2D.linearVelocity = new Vector2(_direction * velocity, rgb2D.linearVelocity.y);
        RaycastHit2D Hit = Physics2D.Raycast(origin.position, Vector2.down, distance, layerinteraction);
        if (Hit.collider != null)
        {
            Debug.DrawRay(origin.position, Vector2.down * distance, conCollision);
            countJumps = 0;
        }
        else
        {
            Debug.DrawRay(origin.position, Vector2.down * distance, sinCollision);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemigo")
        {
            VerificarColor(collision.transform);
            ActualizarTextoVida();
        }
        enColision = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Cuando deja de colisionar, permitir cambiar de color nuevamente
        enColision = false;
    }


    private void VerificarColor(Transform objeto)
    {
        SpriteRenderer colisionObjeto = objeto.GetComponent<SpriteRenderer>();

        if (colisionObjeto != null)
        {
            if (colisionObjeto.color != spriteRenderer.color) // Si el color es diferente
            {
                Debug.Log("¡Recibes daño!");
                Vida();
            }
            else
            {
                Debug.Log("No recibes daño, mismo color.");
            }
        }
    }
    public void Vida()
    {
        vida -= 1;
        Debug.Log("Vida restante: " + vida);
    }
    void CambiarColor(int index)
    {
        colorIndex = index;
        spriteRenderer.color = colores[colorIndex];
    }
    void ActualizarTextoVida()
    {
        if (vidaTexto != null)
        {
            vidaTexto.text = "Vida: " + vida;
        }
    }
    void CambiarColor()
    {
        colorIndex = (colorIndex + 1) % colores.Length; 
        spriteRenderer.color = colores[colorIndex];
    }
}
