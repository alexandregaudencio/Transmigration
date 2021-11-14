using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Realtime;
using Photon.Pun;

[RequireComponent(typeof(Tilemap))]
public class TilemapParallax : MonoBehaviour
{
    [SerializeField] [Range(-1,1)] private float xScroll;
    [SerializeField] [Range(-1,1)] private float yScroll;

    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    //Tilemap tilemap;
    [SerializeField] private GameObject target;

    Vector3 AlvoOosition;

    // Start is called before the first frame update
    void Start()
    {
        //tilemap = GetComponent<Tilemap>();
        
        if (target == null)
        {
            FindLocalCamera();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float newXPos = target.transform.position.x * xScroll +xOffset;
        float newYPos = target.transform.position.y * yScroll + yOffset;
        this.transform.position = new Vector3(newXPos, newYPos, this.transform.position.z);
        
        //Vector2 targetPosition = new Vector2(Vector3.Lerp(transform.position,  newXPos, newYPos);

        //AlvoOosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * xSpeed);
        
        //transform.position = AlvoOosition;


        //Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * smoothPositionSpeed);
        //transform.position = smoothPosition;
    }

    private void FindLocalCamera()
    {
        CameraController[] cameraController = FindObjectsOfType<CameraController>();
        foreach(CameraController camera in cameraController)
        {
            if(camera.targetPlayer == PhotonNetwork.LocalPlayer)
            {
                target = camera.gameObject;
                break;
            }
        }

    }


}
