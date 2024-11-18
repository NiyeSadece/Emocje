using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Gracz
    public Vector3 offset;   // Odleg³oœæ kamery od gracza

    // Update is called once per frame
    void Update()
    {
        // Ustawienie pozycji kamery na pozycjê gracza + offset
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);

        // Kamera nie obraca siê razem z graczem
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}