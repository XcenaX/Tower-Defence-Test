using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
   
[SerializeField]
private Button playBtn, quitBtn;

    void Start()
    {
        playBtn.onClick.AddListener(Play);
        quitBtn.onClick.AddListener(Quit);
    }

    private void Play(){
        SceneManager.LoadScene("EmptyLevel");
    }

    private void Quit(){
        Application.Quit();
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();        
    }
}
