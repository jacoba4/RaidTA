using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void PlayAgain()
    {
        SceneManager.LoadScene("main");
    }
}
