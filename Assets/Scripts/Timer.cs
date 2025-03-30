using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TMP_Text TimerText;
    private float _Time;
    int minutos, segundos, decimas;

    void Update()
    {

        _Time += Time.deltaTime;
        minutos = (int)(_Time / 60f);
        segundos = (int)(_Time % 60f);
        decimas = (int)((_Time - (int)_Time) * 100f);
        TimerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, decimas);
    }
}
