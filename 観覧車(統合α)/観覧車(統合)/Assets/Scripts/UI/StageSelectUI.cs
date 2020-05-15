using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField, Header("対応したシーンの番号")]
    int sceneNumber;

    public void Onclick()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
