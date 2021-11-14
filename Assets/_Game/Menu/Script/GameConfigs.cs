using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigs : MonoBehaviour
{
    public static GameConfigs instance;
    public  byte maxRoomPlayers;
    public  int menuSceneIndex;
    public  int gameplaySceneIndex;

    //player
    public int HP;
    public int timeToRespawn;

    //gameplay
    public float timeGameplay;
    public float timeStartup;


    public Color TeamAColor;
    public Color TeamBColor;


    public KeyCode MeditateKey;
    public Texture2D cursorTexture;
    private void Start()
    {
        instance = this;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

}
