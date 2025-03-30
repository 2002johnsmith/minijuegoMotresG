using TMPro;
using UnityEngine;

public class tiempofinal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text tiempoFinalText;
    void Start()
    {
        string tiempoGuardado = PlayerPrefs.GetString("TiempoFinal"); // Carga el tiempo guardado
        tiempoFinalText.text = "Tiempo Final: " + tiempoGuardado;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
