using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class GainAttack : MonoBehaviour
{

    public VisualEffect gainEffect;
    public SkinnedMeshRenderer bill; // Akses ke Skinned Mesh Renderer objek "bill"
    public Material newMaterial;     // Material baru yang akan diterapkan ke elemen 1
    private Material originalMaterial; // Menyimpan material asli elemen 1
    private bool gain;

    void Start()
    {
        if (gainEffect != null)
        {
            gainEffect.Stop();
        }
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !gain)
        {

            if (gainEffect != null)
            {
                gainEffect.Play();
            }
            gain = true;

            if (bill != null && newMaterial != null)
            {
                ApplyMaterialToBill();
            }

            StartCoroutine(RemoveMaterialAfterDelay(5f)); // Kembalikan material setelah 5 detik
            StartCoroutine(ResetBool(gain, 0.5f));
        }

    }

    private void ApplyMaterialToBill()
    {
        Material[] materials = bill.materials; // Ambil array material
        if (materials.Length > 1) // Pastikan elemen 1 ada
        {
            originalMaterial = materials[1]; // Simpan material asli elemen 1
            materials[1] = newMaterial;      // Ganti dengan material baru
            bill.materials = materials;     // Set ulang materials ke renderer
        }
        else
        {
            Debug.LogWarning("Elemen 1 pada materials tidak ditemukan!");
        }
    }

    private IEnumerator RemoveMaterialAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (bill != null && originalMaterial != null)
        {
            Material[] materials = bill.materials; // Ambil array material
            if (materials.Length > 1) // Pastikan elemen 1 ada
            {
                materials[1] = originalMaterial; // Kembalikan material asli
                bill.materials = materials;     // Set ulang materials ke renderer
            }
        }
    }

    private IEnumerator ResetBool(bool boolToReset, float delay = 0.1f)
    {
        yield return new WaitForSeconds(delay);
        gain = !gain;
    }
}