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

    [Header("Game Limitation")]
    [SerializeField] private Vector3 vectorCamRestriction;
    [SerializeField] private Vector3 sizeCamRestriction;

    public GameObject TargetObject { get => targetobject ;}
    public Player targetPlayer;

    void FixedUpdate()
    {

        TargetPositionUpdate();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(vectorCamRestriction, sizeCamRestriction);
        Gizmos.color = Color.red;
    }

    private void Start()
    {
        DefineLocalPlayerObject();
    }

    private void DefineLocalPlayerObject()
    {
        HPManager[] p = FindObjectsOfType<HPManager>();
        foreach(HPManager playerProp in p)
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

    //void TargetPositionUpdate()
    //{
    //    //alvo = posição alvo + um deslocamento em relação ao eixo x do alvo * ajuste manual;
    //    float targetX = TargetObject.transform.position.x + targetPositionOffSet.x * TargetObject.transform.up.x;
    //    float targetY = TargetObject.transform.position.y + targetPositionOffSet.y * TargetObject.transform.up.y;
    //    float targetZ = TargetObject.transform.position.z - 10f;

    //    float targetXClamped = Mathf.Clamp(targetX, sizeCamRestriction.x, -sizeCamRestriction.x);
    //    float targetYClamped = Mathf.Clamp(targetY, sizeCamRestriction.y, -sizeCamRestriction.y);

    //    Vector3 targetPosition = new Vector3(targetXClamped, targetYClamped, targetZ);

    //    Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothPositionSpeed);
    //    transform.position = smoothPosition;
    //}


}
