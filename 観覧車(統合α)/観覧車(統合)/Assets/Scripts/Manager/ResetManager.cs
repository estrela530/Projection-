using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    [SerializeField]
    GameObject resetCanvas;


    string sceneName;

    private void Start()
    {
        resetCanvas.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCanvas.SetActive(true);
        }
    }

    public void SceneReset()
    {
        sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void ResetCansel()
    {
        resetCanvas.SetActive(false);
    }
}