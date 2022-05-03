using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class ItemSpawnManager : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private event Action itemCollect;
    [SerializeField] private GameObject[] spawnObjects;
    //<summary>
    //Set the Category 
    //</summary>
    [SerializeField] private float waitTimeToSpawnInSeconds;
    private GameObject GetRandomSpawnObject => spawnObjects[UnityEngine.Random.Range(0, spawnObjects.Length)];

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        itemCollect += OnItemCollect;
    }
    private void OnDisable()
    {
        itemCollect -= OnItemCollect;
    }
    private void Start()
    {
        StartSpawnTimer();
    }
    //Método acessível para invocar os eventos de colleta e reiniciar o tempo de spanw
    public void ItemCollect()
    {
        itemCollect?.Invoke();
    }

    private void OnItemCollect()
    {
        audioSource.Play();
        animator.Play("ItemCollect");
        StartSpawnTimer();
    }

    public void StartSpawnTimer()
    {
        StopCoroutine(TimeToSpawn());
        StartCoroutine(TimeToSpawn());
    }

    private IEnumerator TimeToSpawn()
    {
        //Recomeçando o temporizador para spawnar um novo item coletável.
        yield return new WaitForSeconds(waitTimeToSpawnInSeconds);
        SpawnItem();

    }
 
    private void SpawnItem()
    {
        GameObject objectSpawn = Instantiate(GetRandomSpawnObject, transform.position, Quaternion.identity);
        objectSpawn.transform.SetParent(transform);
    }



}
