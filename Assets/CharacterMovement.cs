using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float runMultiplier = 2.0f;
    public float rotationSpeed = 10.0f;
    public float speedSmoothTime = 0.1f; // Tiempo de suavizado para la velocidad

    private Animator animator;
    private CharacterController controller;
    private float currentSpeed = 0.0f;
    private float speedSmoothVelocity;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Obtén la entrada horizontal (eje X) y vertical (eje Z) del jugador.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento.
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);

        // Aplica la velocidad de movimiento.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed * runMultiplier;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        Vector3 movement = moveDirection.normalized * currentSpeed;
        controller.SimpleMove(movement);

        // Actualiza el parámetro "Velocidad" en el Animator con interpolación suave.
        float speedNormalized = Mathf.SmoothDamp(animator.GetFloat("Velocidad"), movement.magnitude / (moveSpeed * runMultiplier), ref speedSmoothVelocity, speedSmoothTime);
        animator.SetFloat("Velocidad", speedNormalized);

        // Rotación del personaje.
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
