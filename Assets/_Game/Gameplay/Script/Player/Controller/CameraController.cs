using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject targetobject;

    [Header("Position")]
    [SerializeField] private float smoothPositionSpeed = 1f;
    [SerializeField] private Vector2 targetPositionOffSet;

    public GameObject TargetObject { get => targetobject; set => targetobject = value; }
    public Player targetPlayer;

    void FixedUpdate()
    {

        TargetPositionUpdate();

    }

    private void Start()
    {
        DefineLocalPlayerObject();
    }

    private void DefineLocalPlayerObject()
    {
        PlayerProperty[] p = FindObjectsOfType<PlayerProperty>();
        foreach(PlayerProperty playerProp in p)
        {
            if(playerProp.PV.Controller == PhotonNetwork.LocalPlayer)
            {
                targetobject = playerProp.gameObject;
                targetPlayer = playerProp.PV.Controller;
                break;
            }
        }

    }

    void TargetPositionUpdate()
    {
        //alvo = posição alvo + um deslocamento em relação ao eixo x do alvo * ajuste manual;
        float targetX = TargetObject.transform.position.x + targetPositionOffSet.x * TargetObject.transform.up.x;
        float targetY = TargetObject.transform.position.y + targetPositionOffSet.y * TargetObject.transform.up.y;
        float targetZ = TargetObject.transform.position.z - 10f;
        Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothPositionSpeed);
        transform.position = smoothPosition;
    }



}
