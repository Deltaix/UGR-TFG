using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionCheck : MonoBehaviour
{
    public Door AngryDoor1, HappyDoor, SadDoor, AngryDoor2, FearDoor;
    private bool ad1, hd, sd, ad2;
    private string emotion;
    private FaceRecon fr;
    public Text txt;
    private int count;
    string[] emotions = { "angry", "disgust", "fear", "happy", "sad", "surprise", "neutral" };
    int[] ocurrencias = { 0, 0, 0, 0, 0, 0, 0 };
    private int max = -1;
    private int indice = -1;

    // Start is called before the first frame update
    void Start()
    {
        ad1 = false;
        hd = false;
        sd = false;
        ad2 = false;
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
            txt.text = emotion;

            if (!ad1)
            {
                if (emotion == "angry")
                {
                    AngryDoor1.Open();
                    ad1 = true;
                }
            }
            else if (!hd)
            {
                if (emotion == "happy")
                {
                    HappyDoor.Open();
                    hd = true;
                }
            }
            else if (!sd)
            {
                if (emotion == "sad")
                {
                    SadDoor.Open();
                    sd = true;
                }
            }
            else if (!ad2)
            {
                if (emotion == "angry")
                {
                    AngryDoor2.Open();
                    ad2 = true;
                }
            }
            else
            {
                if (emotion == "surprise")
                {
                    FearDoor.Open();
                }
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
