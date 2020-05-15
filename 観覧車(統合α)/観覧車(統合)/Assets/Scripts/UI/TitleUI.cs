using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField, Header("ステージ選択のシーン番号")]
    int stageSelectScene;
    

    public void OnClickPlay()
    {
        SceneManager.LoadScene(stageSelectScene);
    }

    public void OnClickEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
