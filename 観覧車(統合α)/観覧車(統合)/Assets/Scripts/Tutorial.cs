using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    float timer;

    [SerializeField, Header("この時間にtextを表示")]
    float Tri;

    [SerializeField, Header("この時間にtext1を表示")]
    float Tri1;

    [SerializeField, Header("この時間にtext2を表示")]
    float Tri2;
    
    [SerializeField, Header("Textをいれる")]
    GameObject Text;

    [SerializeField, Header("Text1をいれる")]
    GameObject Text1;

    [SerializeField, Header("Text2をいれる")]
    GameObject Text2;
    
    int a;

    bool stop;

    // Start is called before the first frame update
    void Start()
    {
         timer = 0;
        //Tri1 = 0;
        //Tri2 = 0;
        //Tri3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
    }

    void TimeUpdate()
    {
        if(!stop)
        {
          timer += 0.01f;
        }

        //textを表示
        if (timer >= Tri)
        {
            Text.SetActive(true);
        }
        //text1を表示
        if (timer >= Tri1)
        {
            Text.SetActive(false);
            Text1.SetActive(true);
        }
        //text2を表示
        if (timer >= Tri2)
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
            stop = true;
        }
        
    }
}
