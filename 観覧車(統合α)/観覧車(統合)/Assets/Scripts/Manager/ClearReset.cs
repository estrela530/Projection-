using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearReset : MonoBehaviour
{
    [SerializeField]
    GameObject resetCanvas;


    string sceneName;

    [SerializeField,Header("飛ばす先のシーン番号")]
    int nextSceneNum = 5;


    private void Start()
    {
        resetCanvas.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
    }
    

    public void SceneReset()
    {
        //SceneManager.LoadScene(sceneName);
        SceneManager.LoadSceneAsync(nextSceneNum);
    }
}
