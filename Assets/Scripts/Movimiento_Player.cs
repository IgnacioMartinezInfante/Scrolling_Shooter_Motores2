using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Player : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float rotationAmount = 15f; // Cantidad de rotación en grados
    public float rotationSpeed = 5f; // Velocidad de rotación
    public float maxSpeed = 5f; // Velocidad máxima
    public float brakeSpeed = 5f; // Velocidad de frenado

    private Rigidbody rb;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Captura el input del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula el movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;

        // Aplica fuerza al Rigidbody para mover la nave
        rb.AddForce(movement);

        // Limita la velocidad máxima
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Aplica frenado si no hay input
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, brakeSpeed * Time.deltaTime);
        }

        // Calcula la rotación objetivo
        float tiltZ = moveHorizontal * -rotationAmount;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, tiltZ);

        // Interpola hacia la rotación deseada para suavizar el movimiento
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}