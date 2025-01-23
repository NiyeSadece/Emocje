using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencja do gracza
    public Vector3 offset;   // Offset kamery wzglêdem gracza

    void LateUpdate()
    {
        // Ustawienie pozycji kamery: poruszanie w osi X i Y, zablokowanie osi Z
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Zachowanie sta³ej rotacji kamery (opcjonalne)
        transform.rotation = Quaternion.identity; // Zerowanie rotacji kamery
    }
}
