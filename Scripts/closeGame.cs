using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGame : MonoBehaviour
{

    bool helpOpen = false;
    // Start is called before the first frame update
    public void openQuitScreen()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        Transform quitPanel = mainCanvas.transform.Find("sureQuit");
        quitPanel.gameObject.SetActive(true);

    }

    public void closeQuitScreen()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        Transform quitPanel = mainCanvas.transform.Find("sureQuit");
        quitPanel.gameObject.SetActive(false);

    }

    public void CloseGame()
    {
        Application.Quit();

    }

    public void openHelp()
    {
        if (helpOpen == false)
        {
            GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
            Transform help = mainCanvas.transform.Find("help");
            help.gameObject.SetActive(true);
            helpOpen = true;
        }
        else if (helpOpen == true)
        {
            GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
            Transform help = mainCanvas.transform.Find("help");
            help.gameObject.SetActive(false);
            helpOpen = false;
        }

    }
}
