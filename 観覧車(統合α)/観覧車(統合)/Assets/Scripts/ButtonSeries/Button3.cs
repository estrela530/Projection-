using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3 : MonoBehaviour
{
    [SerializeField]
    int nextSceneNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ボタンを押したときの処理メソッド
    public void OnClickStartButton()
    {
        SceneManager.LoadSceneAsync(nextSceneNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
