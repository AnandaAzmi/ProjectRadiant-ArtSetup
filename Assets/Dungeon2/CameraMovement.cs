
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movespeed = 5f;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * movespeed * Time.deltaTime;
    }
}
