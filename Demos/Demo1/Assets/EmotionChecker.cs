using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionChecker : MonoBehaviour
{
    private string emotion;
    private FaceRecon fr;
    private int count;
    string[] emotions = { "angry", "disgust", "fear", "happy", "sad", "surprise", "neutral" };
    int[] ocurrencias = { 0, 0, 0, 0, 0, 0, 0 };
    private int max = -1;
    private int indice = -1;

    // Start is called before the first frame update
    void Start()
    {
        emotion = "";
        fr = GetComponent<FaceRecon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 30)
        {
            for (int i = 0; i < 7; i++)
            {
                if (ocurrencias[i] > max)
                {
                    max = ocurrencias[i];
                    indice = i;
                }

                ocurrencias[i] = 0;
            }

            emotion = emotions[indice];

            if (emotion == "angry" || emotion == "disgust" || emotion == "fear" || emotion == "sad")
            {
                PlayerPrefs.SetInt("difficulty", 0);
            }
            else
            {
                PlayerPrefs.SetInt("difficulty", 1);
            }

            count = 0;
            emotion = "";
            max = -1;
            indice = -1;
        }

        else
        {
            emotion = fr.GetEmotion();
            if (emotion != "")
            {
                ocurrencias[System.Array.IndexOf(emotions, emotion)]++;
                count++;
                emotion = "";
            }
        }
    }
}
