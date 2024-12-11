using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransisi : MonoBehaviour
{
    void Update()
    {
        // Deteksi tombol keyboard angka 1, 2, atau 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchScene(0); // Pindah ke scene index 0
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchScene(1); // Pindah ke scene index 1
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchScene(2); // Pindah ke scene index 2
        }
    }

    // Method untuk berpindah ke scene tertentu berdasarkan urutan index scene
    public void SwitchScene(int sceneIndex)
    {
        // Pastikan index scene valid sebelum berpindah
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Scene index out of range: " + sceneIndex);
        }
    }
}