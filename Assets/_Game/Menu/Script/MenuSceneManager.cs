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
        timer.timeOver += GoToGameplayScene;
    }
    private void OnDisable()
    {
        timer.timeOver -= GoToGameplayScene;
    }

    public  void GoToGameplayScene()
    {
        Debug.Log("Timer over!");
        SceneManager.LoadScene(GameConfigs.instance.GameplaySceneIndex);
    }

}
