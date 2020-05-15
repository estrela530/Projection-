using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChengeManager : MonoBehaviour
{
    [SerializeField]
    string currentSceneName;
    int currentSceneNum = 0;
    string nextSceneName;
    int nextSceneNum;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //シーン管理（切り替え用）メソッド
    public void SceneChenge()
    {
        currentSceneNum += 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
