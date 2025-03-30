using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    public Image RellenoDeVida;
    private Player Player;
    private float VidaMaxima;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player=GameObject.Find("Personaje").GetComponent<Player>();
        VidaMaxima = Player.vida;
    }

    // Update is called once per frame
    void Update()
    {
        RellenoDeVida.fillAmount = Player.vida / VidaMaxima;
    }
}
