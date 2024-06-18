using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles_Player : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public List<Transform> firePoints; // Lista de puntos de disparo
    public float fireRate = 0.5f; // Frecuencia de disparo en segundos

    private float nextFireTime = 0f; // Tiempo para el siguiente disparo
    private int fireMode = 1; // Modo de disparo: 1 = un proyectil, 2 = dos proyectiles

    void Update()
    {
        // Disparo de proyectiles
        if (Time.time > nextFireTime)
        {
            FireProjectiles();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireProjectiles()
    {
        if (fireMode == 1)
        {
            // Dispara un proyectil desde cada punto de disparo
            foreach (Transform firePoint in firePoints)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
        }
        else if (fireMode == 2)
        {
            // Dispara dos proyectiles desde cada punto de disparo
            foreach (Transform firePoint in firePoints)
            {
                Instantiate(projectilePrefab, firePoint.position + new Vector3(-0.5f, 0, 0), firePoint.rotation);
                Instantiate(projectilePrefab, firePoint.position + new Vector3(0.5f, 0, 0), firePoint.rotation);
            }
        }
    }

    public void SetFireMode(int mode)
    {
        fireMode = mode;
    }
}
