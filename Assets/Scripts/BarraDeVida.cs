using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image relleno;
    public Vida_Player player;
    private float VidaMaxima; // Vida máxima del jugador
    private float VidaActual; // Vida actual del jugador
    
    void Update()
    {
        if (player != null)
        {
            VidaMaxima = player.vidamaxima;
            VidaActual = player.vidaactual;
            relleno.fillAmount = VidaActual / VidaMaxima;
        }
    }
}
