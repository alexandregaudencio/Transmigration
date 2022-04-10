using CharacterNamespace;
using Photon.Pun;
using System;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public event Action<float> changeHP;
    public event Action hpEmpty;
    private CharacterProperty characterProperty;
    private float hp;
    public float MaxHP => characterProperty.HP;
    public float Hp { get => hp; set => hp = value; }

    public float HPfraction => Hp / MaxHP;

    private void Awake()
    {
        characterProperty = GetComponent<PlayerController>().CharacterProperty;
    }
    private void OnEnable()
    {
        changeHP += CheckHPIsEmpty;
    }

    private void OnDisable()
    {
        changeHP -= CheckHPIsEmpty;
    }

    private void Start()
    {
        ResetHP();
    }

    public void IncreaseHP(float value)
    {
            Hp =  (Hp + value <= MaxHP) ? (Hp+value) : MaxHP;
            changeHP?.Invoke(Hp);
    }
    

    public void DecreaseHP(float value)
    {
            Hp = (Hp - value >= 0) ? (Hp-value) : 0;
            changeHP?.Invoke(Hp);
    }
    public void ResetHP() { 
        Hp = MaxHP;
        changeHP?.Invoke(Hp);
    }

    public void CheckHPIsEmpty(float HP)
    {
        if (HP <= 0)
        {
            hpEmpty?.Invoke();
        }
    }

}
