using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingAuto : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] _textMeshProArray;  // Array untuk menyimpan 3 TextMeshProUGUI
    [SerializeField] AudioSource typingAudio;  // Komponen AudioSource untuk suara typing
    public float timeBtwnChar;
    public float timeBtwnwords;
    public string[] stringArray;  // Array berisi string yang akan ditampilkan
    int i = 0;

    // Start is called before the first frame update
    public void Start()
    {
        // Menonaktifkan semua TextMeshPro sebelum memulai
        foreach (var text in _textMeshProArray)
        {
            text.gameObject.SetActive(false);
        }

        //PlayHere();  // Mulai proses pengetikan
    }

    public void PlayHere()
    {
        // Pastikan indeks tidak lebih besar dari jumlah string yang ada
        if (i < stringArray.Length)
        {
            int textIndex = i; // Gunakan i untuk menentukan komponen TextMeshPro yang digunakan
            if (textIndex < _textMeshProArray.Length)
            {
                _textMeshProArray[textIndex].text = stringArray[i];  // Set teks pada TextMeshPro yang sesuai
                _textMeshProArray[textIndex].gameObject.SetActive(true);  // Mengaktifkan TextMeshPro untuk indeks ini

                // Mainkan suara typing
                if (typingAudio != null && !typingAudio.isPlaying)
                {
                    typingAudio.Play();
                }

                StartCoroutine(TextVisible(_textMeshProArray[textIndex]));
            }
        }
    }

    private IEnumerator TextVisible(TextMeshProUGUI textMeshPro)
    {
        textMeshPro.ForceMeshUpdate();
        int totalVisibleChar = textMeshPro.textInfo.characterCount;
        int counter = 0;
        while (true)
        {
            int visibleCount = counter % (totalVisibleChar + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleChar)
            {
                i += 1;  // Increment untuk ke string berikutnya
                Invoke("PlayHere", timeBtwnwords);  // Tunggu beberapa detik sebelum melanjutkan

                // Hentikan suara typing jika selesai
                if (typingAudio != null && typingAudio.isPlaying)
                {
                    typingAudio.Stop();
                }

                break;
            }

            counter += 1;

            yield return new WaitForSeconds(timeBtwnChar);
        }
    }
}
