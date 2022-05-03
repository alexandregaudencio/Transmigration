using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private Timer timer;

    
    private void OnEnable()
    {
        timer.onTimeOver += GoToGameplayScene;
    }
    private void OnDisable()
    {
        timer.onTimeOver -= GoToGameplayScene;
    }

    public  void GoToGameplayScene()
    {
        SceneManager.LoadScene(GameConfigs.instance.GameplaySceneIndex);
    }

}
