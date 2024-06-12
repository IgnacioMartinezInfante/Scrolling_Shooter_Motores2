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

    // Método para recibir daño
    public void RecibirDaño(float daño)
    {
        vidaactual -= daño;
        Debug.Log("Vida restante del jugador: " + vidaactual);

        if (vidaactual <= 0)
        {
            // Aquí puedes agregar lógica para cuando el jugador muere
            Debug.Log("El jugador ha muerto.");
        }
    }

    // Método para detectar colisiones
    void OnTriggerEnter(Collider other)
    {
        // Intenta obtener el componente del objeto colisionado que implementa IDañoJugador
        IDañoJugador enemigo = other.gameObject.GetComponent<IDañoJugador>();

        // Si el objeto colisionado implementa IDañoJugador
        if (enemigo != null)
        {
            // El jugador recibe daño
            RecibirDaño(enemigo.ObtenerDaño());

            // Destruye el enemigo
            Destroy(other.gameObject);
        }
    }
}
