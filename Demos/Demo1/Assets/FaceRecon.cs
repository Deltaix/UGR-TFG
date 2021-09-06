using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Diagnostics;

public class FaceRecon : MonoBehaviour
{
    Process process = new Process();
    StreamReader sr;

    // Start is called before the first frame update
    void Start()
    {
        string python = @"D:/Users/JP/PycharmProjects/pythonProject/venv2/Scripts/python.exe";
        string pythonApp = @"-u D:/Users/JP/PycharmProjects/pythonProject/scriptpython.py";

        ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

        myProcessStartInfo.UseShellExecute = false;
        myProcessStartInfo.RedirectStandardOutput = true;
        myProcessStartInfo.RedirectStandardError = true;
        myProcessStartInfo.RedirectStandardInput = true;
        myProcessStartInfo.CreateNoWindow = true;
        myProcessStartInfo.WindowStyle = ProcessWindowStyle.Minimized;

        myProcessStartInfo.Arguments = pythonApp;

        process.StartInfo = myProcessStartInfo;

        process.Start();

        sr = process.StandardOutput;
    }

    public void KillRecon()
    {
        process.Kill();
        UnityEngine.Debug.Log("Proceso matado");
    }

    public string GetEmotion()
    {
        string salida;
        salida = sr.ReadLine();
        return salida;
    }
}
