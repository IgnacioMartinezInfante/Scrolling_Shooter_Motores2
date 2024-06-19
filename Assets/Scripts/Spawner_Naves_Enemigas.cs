using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Naves_Enemigas : MonoBehaviour
{
    public GameObject[] enemigosToSpawn; // Array de enemigos que serán spawneados
    public GameObject bossToSpawn; // El jefe final que será spawneado
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada spawn
    public Vector3[] spawnPositions; // Coordenadas de spawn
    public Vector3 bossSpawnPosition; // Coordenada de spawn del jefe final

    private List<Vector3> posicionesDisponibles;
    private int navesInstanciadas = 0; // Contador de naves instanciadas
    private int navesDestruidas = 0; // Contador de naves destruidas
    private bool bossDestruido = false;

    public GameObject victoryCanvas;

    void Start()
    {
        victoryCanvas.SetActive(false);
        // Inicializa la lista de posiciones disponibles con las posiciones de spawn iniciales
        posicionesDisponibles = new List<Vector3>(spawnPositions);

        // Comienza a spawnear enemigos repetidamente
        StartCoroutine(SpawnEnemigos());
    }

    IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            // Espera el tiempo especificado antes de spawnear el siguiente enemigo
            yield return new WaitForSeconds(spawnInterval);

            if (navesInstanciadas < 6)
            {
                // Si no hay posiciones disponibles, reinicia la lista
                if (posicionesDisponibles.Count == 0)
                {
                    posicionesDisponibles = new List<Vector3>(spawnPositions);
                }

                // Escoge una posición de spawn aleatoria de las disponibles
                int randomIndex = Random.Range(0, posicionesDisponibles.Count);
                Vector3 spawnPosition = posicionesDisponibles[randomIndex];

                // Elimina la posición seleccionada de la lista de disponibles
                posicionesDisponibles.RemoveAt(randomIndex);

                // Escoge un enemigo aleatorio para spawnear
                GameObject enemigoToSpawn = enemigosToSpawn[Random.Range(0, enemigosToSpawn.Length)];

                // Instancia el enemigo en la posición de spawn seleccionada con una rotación de 270 grados en el eje Y
                Instantiate(enemigoToSpawn, spawnPosition, Quaternion.Euler(0, 270, 0));

                // Incrementa el contador de naves instanciadas
                navesInstanciadas++;
            }

            // Detiene la corrutina si se han instanciado 6 naves
            if (navesInstanciadas >= 6)
            {
                yield break;
            }
        }
    }

    // Llama a este método cuando una nave es destruida
    public void NaveDestruida()
    {
        navesDestruidas++;

        if (navesDestruidas == 6)
        {
            // Instancia el jefe final en la posición de spawn designada con una rotación de 270 grados en el eje Y
            Instantiate(bossToSpawn, bossSpawnPosition, Quaternion.Euler(0, 270, 0));
        }

        if (navesDestruidas > 6)
        {
            Debug.Log("Juego terminado");
            victoryCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
