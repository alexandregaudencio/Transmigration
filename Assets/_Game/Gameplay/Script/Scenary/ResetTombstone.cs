using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTombstone : MonoBehaviour
{


    [SerializeField] private GameObject tombstone;

    TombstoneController tombstoneController;

    private void Awake()
    {
        tombstoneController = tombstone.GetComponent<TombstoneController>();

    }


    public IEnumerator ResetingTombstone()
    {
        yield return new WaitForSeconds(GameConfigs.instance.resetTombstonetime);
        tombstone.SetActive(true);
        tombstoneController.meditatingCount = 0;
    }

}
