using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float shipSpeed = 10f; // Velocitat de la nau
    private Rigidbody rb;

    void Start()
    {
        // Obtenim el Rigidbody2D per controlar el moviment
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtenim les entrades del teclat o mòbil
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        // Creem el vector de moviment
        Vector3 movement = new Vector3(moveHorizontal, moveVertical);

        // Movem la nau amb la velocitat ajustada pel Rigidbody2D
        rb.linearVelocity = movement * shipSpeed;
    }
}
