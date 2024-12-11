using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalScript : MonoBehaviour
{
    public ParticleSystem[] particleEffects; // Array untuk menampung semua prefab partikel
    public float targetPlaybackTime = 0.99f; // Playback time yang diinginkan

    void Start()
    {
        foreach (ParticleSystem particleEffect in particleEffects)
        {
            if (particleEffect != null)
            {
                particleEffect.Stop(); // Pastikan partikel berhenti di awal
                particleEffect.time = targetPlaybackTime; // Atur playback time ke target
                particleEffect.Play(); // Mainkan partikel
            }
        }
    }

    void Update()
    {
        foreach (ParticleSystem particleEffect in particleEffects)
        {
            if (particleEffect != null && particleEffect.time >= particleEffect.main.duration)
            {
                particleEffect.Stop(); // Hentikan ketika durasi partikel selesai
                particleEffect.time = targetPlaybackTime; // Atur ulang playback time
                particleEffect.Play(); // Mainkan lagi partikel dari playback time yang diinginkan
            }
        }
    }
}
