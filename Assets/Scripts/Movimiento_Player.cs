using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Player : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float rotationAmount = 15f; // Cantidad de rotaci�n en grados
    public float rotationSpeed = 5f; // Velocidad de rotaci�n
    public float maxSpeed = 5f; // Velocidad m�xima
    public float brakeSpeed = 5f; // Velocidad de frenado

    // L�mites del movimiento del jugador en los ejes X y Z
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

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
        Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal) * moveSpeed;

        // Aplica fuerza al Rigidbody para mover la nave
        rb.AddForce(movement);

        // Limita la velocidad m�xima
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Aplica frenado si no hay input
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, brakeSpeed * Time.deltaTime);
        }

        // Limita la posici�n del jugador dentro de los l�mites especificados
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
        transform.position = clampedPosition;

        // Calcula la rotaci�n objetivo
        float tiltZ = moveHorizontal * -rotationAmount;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, tiltZ);

        // Interpola hacia la rotaci�n deseada para suavizar el movimiento
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}