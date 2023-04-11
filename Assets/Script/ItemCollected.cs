using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollected : MonoBehaviour
{
    public Image collectSign;

    void Start()
    {
        collectSign.enabled = false;
    }

    private void OnEnable()
    {
       //  UnityEngine.Debug.Log("aaaa");

        Collectable.CollectableCollected += ShowCollectSign;
    }

    private void OnDisable()
    {
        Collectable.CollectableCollected -= ShowCollectSign;
    }

    void ShowCollectSign()
    {
        collectSign.enabled = true;
        StartCoroutine(HideCollectSign());
    }

    IEnumerator HideCollectSign()
    {
        yield return new WaitForSeconds(1f);
        collectSign.enabled = false;
    }
}
