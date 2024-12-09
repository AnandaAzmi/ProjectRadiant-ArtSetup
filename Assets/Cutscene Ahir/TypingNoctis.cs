using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingNoctis : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshPro;
    public float timeBtwnChar;
    public string[] stringArray;
    public float[] timeBtwnSentences; // Waktu jeda per kalimat


    private int i = 0;

    // Start is called before the first frame update
    public void Start()
    {
        // Menonaktifkan TextMeshPro sebelum memulai
        _textMeshPro.gameObject.SetActive(false);

    }

    public void PlayHere()
    {

        if (i < stringArray.Length)
        {
            _textMeshPro.text = stringArray[i];
            _textMeshPro.gameObject.SetActive(true);  // Mengaktifkan TextMeshPro sebelum mulai mengetik
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleChar = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleChar + 1);
            _textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleChar)
            {
                i++;
                if (i < stringArray.Length)
                {
                    float delay = (i - 1 < timeBtwnSentences.Length) ? timeBtwnSentences[i - 1] : 1f; // Default 1 detik jika array tidak sesuai
                    Invoke("PlayHere", delay);
                }
                break;
            }

            counter++;
            yield return new WaitForSeconds(timeBtwnChar);
        }
    }


}
