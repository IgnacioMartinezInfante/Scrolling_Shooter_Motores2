using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles_Mec�nicas : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo de vida de la bala antes de ser destruida
    public float damage = 5f;

    void Start()
    {
        // Destruye la bala despu�s de un tiempo definido
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante en l�nea recta
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si la bala colision� con un objeto con el tag "Enemigo"
        if (other.CompareTag("Enemy"))
        {
            // Intenta obtener el componente IDamageable del objeto colisionado
            IDa�o damageable = other.GetComponent<IDa�o>();

            // Si el objeto colisionado implementa la interfaz IDamageable, llama a su m�todo RecibirDa�o
            if (damageable != null)
            {
                damageable.RecibirDa�o(damage);
            }

            // Destruye la bala
            Destroy(gameObject);
        }
    }
}
