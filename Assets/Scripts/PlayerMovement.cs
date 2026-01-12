using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    InputSystem_Actions inputActions;
    float moveSpeed = 8f;
    private Rigidbody rb;
    Vector3 movement;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        float moveX = inputVector.x;
        float moveY = inputVector.y;

        transform.position += new Vector3(moveX, 0, moveY).normalized * moveSpeed * Time.deltaTime;

        movement = new Vector3(moveX, 0, moveY);

    }

    private void FixedUpdate()
    {
        Movement(movement);
    }

    void Movement(Vector3 movement)
    {
        rb.angularVelocity = movement * Time.deltaTime;
    }
}
