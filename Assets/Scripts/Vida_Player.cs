using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_Player : MonoBehaviour
{
    public float vidamaxima = 100f;
    public float vidaactual;

    private void Start()
    {
        vidaactual = vidamaxima; // Vida del jugador
    }

    // M�todo para recibir da�o
    public void RecibirDa�o(float da�o)
    {
        vidaactual -= da�o;
        Debug.Log("Vida restante del jugador: " + vidaactual);

        if (vidaactual <= 0)
        {
            // Aqu� puedes agregar l�gica para cuando el jugador muere
            Debug.Log("El jugador ha muerto.");
        }
    }

    // M�todo para detectar colisiones
    void OnTriggerEnter(Collider other)
    {
        // Intenta obtener el componente del objeto colisionado que implementa IDa�oJugador
        IDa�oJugador enemigo = other.gameObject.GetComponent<IDa�oJugador>();

        // Si el objeto colisionado implementa IDa�oJugador
        if (enemigo != null)
        {
            // El jugador recibe da�o
            RecibirDa�o(enemigo.ObtenerDa�o());

            // Destruye el enemigo
            Destroy(other.gameObject);
        }
    }
}
