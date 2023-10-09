using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        float speed = inputDirection.magnitude;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Running
            speed = Mathf.Clamp01(speed) * runSpeed;
        }
        else
        {
            // Walking
            speed = Mathf.Clamp01(speed) * walkSpeed;
        }

        // Actualiza el parámetro de velocidad en el Animator
        animator.SetFloat("Velocidad", speed);
    }
}
