using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Piedras : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array de objetos que serán spawneados
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada spawn
    public Vector3[] spawnPositions; // Coordenadas de spawn

    void Start()
    {
        // Comienza a spawnear objetos repetidamente
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Espera el tiempo especificado antes de spawnear el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);

            // Escoge un objeto aleatorio para spawnear
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Escoge una posición de spawn aleatoria
            Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

            // Instancia el objeto en la posición de spawn seleccionada
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
