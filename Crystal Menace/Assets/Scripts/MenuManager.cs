using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        
        Application.Quit();
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene(1);
    }
}
