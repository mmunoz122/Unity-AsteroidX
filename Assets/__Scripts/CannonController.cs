using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    // Update es crida una vegada per fotograma
    void Update()
    {
        // Obtenir la posició del ratolí al món
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Només fem servir les posicions X i Z per tal que la torreta giri en el pla horitzontal
        mousePosition.z = transform.position.z;

        // Calcular la direcció cap al ratolí
        Vector3 direction = mousePosition - transform.position;

        // Calcular la rotació necessària per mirar cap a la direcció
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Aplicar la rotació a la torreta
        transform.rotation = rotation;
    }
}
