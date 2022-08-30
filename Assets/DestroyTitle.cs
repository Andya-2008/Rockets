using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("TitleCanvasDestroyed") == 0)
        {
            PlayerPrefs.SetInt("TitleCanvasDestroyed",1);
            Destroy(GameObject.Find("TitleCanvas").gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
