using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody2D rgb2D;

    [Header("Salto")]
    [SerializeField] private float jumpforce;
    [SerializeField] private int countJumps;
    [SerializeField] private int maxjumps;
    [SerializeField] private bool canJump=true;
    [SerializeField] private Transform origin;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layerinteraction;
    [SerializeField] private Color conCollision=Color.green;
    [SerializeField] private Color sinCollision=Color.red;

    float _direction = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgb2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && countJumps<maxjumps)  
        {
            rgb2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            countJumps++;
        }
    }
    private void FixedUpdate()
    {
        rgb2D.linearVelocity = new Vector2(_direction * velocity, rgb2D.linearVelocity.y);
        RaycastHit2D Hit = Physics2D.Raycast(origin.position, Vector2.down, distance, layerinteraction);
        if (Hit.collider != null)
        {
            Debug.DrawRay(origin.position,Vector2.down* distance, conCollision);
            countJumps=0;
        }
        else
        {
            Debug.DrawRay(origin.position, Vector2.down * distance, sinCollision);
        }
    }
}
