using UnityEngine;

public class BulletAnchor : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform cannon; // Transform del cañón desde donde se dispara

    void Update()
    {
        // Comprobar si el jugador presiona el botón Fire1 (clic izquierdo del ratón)
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Crear el proyectil en la posición y rotación del cañón
        GameObject bullet = Instantiate(bulletPrefab, cannon.position, cannon.rotation);

        // Establecer el nombre del proyectil sin "(Clone)"
        bullet.name = "Bullet"; // O puedes añadir algo único si prefieres

        // Obtener el Rigidbody del proyectil para aplicar fuerza
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El prefab del proyectil no tiene un componente Rigidbody.");
            Destroy(bullet); // Destruir si no tiene Rigidbody
            return;
        }

        // Obtener la posición del ratón en coordenadas de pantalla y convertirla a coordenadas del mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(cannon.position).z; // Mantener la misma profundidad (z)

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcular la dirección hacia la posición del ratón y normalizarla
        Vector3 direction = (worldMousePosition - cannon.position).normalized;

        // Aplicar velocidad al proyectil
        rb.linearVelocity = direction * 10f; // Velocidad del proyectil

        // Opcional: destruir el proyectil después de 2 segundos
        Destroy(bullet, 2f);
    }
}
