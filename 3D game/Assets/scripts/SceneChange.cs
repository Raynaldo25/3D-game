using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        if (FindObjectOfType<gameManager>())
        {
            FindObjectOfType<gameManager>().endTime = 15;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}

