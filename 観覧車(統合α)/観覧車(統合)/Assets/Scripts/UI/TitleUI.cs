using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField, Header("ステージ選択のシーン番号")]
    int stageSelectScene;

    [SerializeField]
    float startSeconds = 0;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    bool isStart = false;

    [SerializeField]
    string animName;

    public void OnClickPlay()
    {
        isStart = true;

        //if (isStart == true)
        //{
        //    startSeconds +=(int)Time.deltaTime;
        //}

        //if (startSeconds >= 3)
        //{
        //    MoveScene();
        //}
    }

    public void MoveScene()
    {
        if (isStart == true)
        {
            animator.SetBool(animName, true);

            startSeconds += Time.deltaTime;

            if (startSeconds >= 0.5)
            {
                SceneManager.LoadScene(stageSelectScene);
                Debug.Log("きた");
            }
        }
    }

    void Update()
    {
        MoveScene();
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
