using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefabricat de la bala
    public Transform cannon; // Posició del canó

    void Update()
    {
        // Si el botó "Fire1" (botó esquerre del ratolí) és premut
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Crear la bala a la posició i rotació del canó
        GameObject bullet = Instantiate(bulletPrefab, cannon.position, cannon.rotation);

        // Assignar el pare de la bala a "BulletAnchor" per mantenir l'estructura neta
        bullet.transform.parent = GameObject.Find("BulletAnchor").transform;

        // Obtenir el component Rigidbody per controlar la velocitat de la bala
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Obtenir la posició del ratolí en coordenades de pantalla i convertir a coordenades del món
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = cannon.position.z; // Mantenir la bala a la mateixa coordenada z que el canó

        // Calcular la direcció del canó cap a la posició del ratolí i normalitzar-la
        Vector3 direction = (mousePosition - cannon.position).normalized;

        // Assignar la velocitat de la bala en funció de la direcció calculada
        rb.linearVelocity = direction * 10f;

        // Destruir la bala després de 2 segons
        Destroy(bullet, 2f);
    }
}
