using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vége : MonoBehaviour
{
    // Start is called before the first frame update
    public void start()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void kilepes()
    {
        Application.Quit();
        Debug.Log("qiut");
    }
}
