using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles_Mecánicas : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo de vida de la bala antes de ser destruida
    public float damage = 5f;

    void Start()
    {
        // Destruye la bala después de un tiempo definido
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante en línea recta
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si la bala colisionó con un objeto con el tag "Enemigo"
        if (other.CompareTag("Enemy"))
        {
            // Intenta obtener el componente IDamageable del objeto colisionado
            IDaño damageable = other.GetComponent<IDaño>();

            // Si el objeto colisionado implementa la interfaz IDamageable, llama a su método RecibirDaño
            if (damageable != null)
            {
                damageable.RecibirDaño(damage);
            }

            // Destruye la bala
            Destroy(gameObject);
        }
    }
}
