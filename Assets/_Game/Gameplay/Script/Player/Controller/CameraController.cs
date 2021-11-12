using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject targetPlayer;

    [Header("Position")]
    [SerializeField] private float smoothPositionSpeed = 1f;
    [SerializeField] private Vector2 targetPositionOffSet;

    public GameObject TargetPlayer { get => targetPlayer; set => targetPlayer = value; }

    public static CameraController instance;

    

    void FixedUpdate()
    {

        TargetPositionUpdate();

    }

    private void Start()
    {
        instance = this;
        SetLocalGameObject();
    }

    private void SetLocalGameObject()
    {
        PlayerProperty[] p = FindObjectsOfType<PlayerProperty>();
        foreach(PlayerProperty playerProp in p)
        {
            if(playerProp.PV.Controller == PhotonNetwork.LocalPlayer)
            {
                targetPlayer = playerProp.gameObject;
                break;
            }
        }

    }

    void TargetPositionUpdate()
    {
        //alvo = posição alvo + um deslocamento em relação ao eixo x do alvo * ajuste manual;
        float targetX = TargetPlayer.transform.position.x + targetPositionOffSet.x * TargetPlayer.transform.up.x;
        float targetY = TargetPlayer.transform.position.y + targetPositionOffSet.y * TargetPlayer.transform.up.y;
        float targetZ = TargetPlayer.transform.position.z - 10f;
        Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothPositionSpeed);
        transform.position = smoothPosition;
    }



}
