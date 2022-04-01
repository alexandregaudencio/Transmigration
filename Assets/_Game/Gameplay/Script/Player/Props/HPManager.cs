using CharacterNamespace;
using Photon.Pun;
using System;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public event Action<float> changeHPEvent;
    private CharacterProperty characterProperty;
    private float hp;
    public float MaxHP => characterProperty.HP;
    public float Hp { get => hp; set => hp = value; }

    public float HPfraction => Hp / MaxHP;

    private void Awake()
    {
        characterProperty = GetComponent<PlayerController>().CharacterProperty;
    }

    private void Start()
    {
        ResetHP();
        Debug.Log(Hp);
    }
    public void IncreaseHP(float value)
    {
            Hp =  (Hp + value <= MaxHP) ? (Hp+value) : MaxHP;
            changeHPEvent?.Invoke(Hp);
    }
    

    public void DecreaseHP(float value)
    {
            Hp = (Hp - value >= 0) ? (Hp-value) : 0;
            changeHPEvent?.Invoke(Hp);
    }
    public void ResetHP() { 
        Hp = MaxHP;
        changeHPEvent?.Invoke(Hp);
    }

    public void ResetPlayerPrps(Vector3 spawnPosition)
    {
        ////TODO: not working great.
        //HashProperty["HP"] = (float)PhotonNetwork.LocalPlayer.CustomProperties["maxHP"];
        //HashProperty["isDead"] = false;
        //PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);
        //GetComponent<SpriteRenderer>().enabled = true;
        //transform.position = spawnPosition;


    }
}
