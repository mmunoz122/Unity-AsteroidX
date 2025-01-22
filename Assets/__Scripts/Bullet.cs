using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Destruïm la bala després de 2 segons
        Destroy(gameObject, 2f); // Destrueix l'objecte (la bala) després de 2 segons
    }
}
