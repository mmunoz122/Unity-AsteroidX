using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;  // Variable per emmagatzemar la càmera principal
    private float screenWidth;  // Amplada de la pantalla (en unitats del món)
    private float screenHeight; // Alçada de la pantalla (en unitats del món)

    void Start()
    {
        // Obtenim la càmera principal de l'escena
        mainCamera = Camera.main;

        // Calculem l'amplada de la pantalla utilitzant el tamany ortogràfic de la càmera i el seu aspecte
        screenWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // Calculem l'alçada de la pantalla només utilitzant el tamany ortogràfic de la càmera
        screenHeight = mainCamera.orthographicSize;
    }

    void Update()
    {
        // Obtenim la posició actual de l'objecte
        Vector3 position = transform.position;

        // Comprovem si l'objecte ha sortit de la pantalla pel costat dret
        if (position.x > screenWidth) position.x = -screenWidth;

        // Comprovem si l'objecte ha sortit de la pantalla pel costat esquerre
        if (position.x < -screenWidth) position.x = screenWidth;

        // Comprovem si l'objecte ha sortit de la pantalla per la part superior
        if (position.z > screenHeight) position.z = -screenHeight;

        // Comprovem si l'objecte ha sortit de la pantalla per la part inferior
        if (position.z < -screenHeight) position.z = screenHeight;

        // Actualitzem la posició de l'objecte per mantenir-lo dins de la pantalla
        transform.position = position;
    }
}
