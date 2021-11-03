using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject targetPlayer;

    [Header("Position")]
    [SerializeField] private float smoothPositionSpeed = 1f;
    [SerializeField] private Vector2 targetPositionOffSet;




    void FixedUpdate()
    {
        TargetPositionUpdate();

    }

    void TargetPositionUpdate()
    {
        //alvo = posição alvo + um deslocamento em relação ao eixo x do alvo * ajuste manual;
        float targetX = targetPlayer.transform.position.x + targetPositionOffSet.x * targetPlayer.transform.up.x;
        float targetY = targetPlayer.transform.position.y + targetPositionOffSet.y * targetPlayer.transform.up.y;
        float targetZ = targetPlayer.transform.position.z - 10f;
        Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothPositionSpeed);
        transform.position = smoothPosition;
    }



}
