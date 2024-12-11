using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemeny : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerakan kamera

    void Update()
    {
        // Mendapatkan input dari tombol W, A, S, D
        float horizontal = Input.GetAxis("Horizontal"); // A (-1) atau D (+1)
        float vertical = Input.GetAxis("Vertical"); // S (-1) atau W (+1)

        // Menghitung arah gerakan kamera
        Vector3 direction = new Vector3(horizontal,0f, vertical);

        // Menggerakkan kamera sesuai arah dan kecepatan yang ditentukan
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
