using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class R_427_dev : InfoModelBehaviour
{
    private Process currentProcess;
    private Process devProcess;
    private bool isEntered = false;

    public override void onRaycastClick()
    {

        try
        {
            currentProcess = Process.GetCurrentProcess();

            devProcess = new Process();
            devProcess.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() +
                "\\Assets\\development_program\\Программа по Р-427\\RStation.exe";
            devProcess.Start();
            currentProcess.Start();
        }
        catch (Exception e)
        {

        }
        
    }

    public override void onRaycastClose()
    {

    }
}
