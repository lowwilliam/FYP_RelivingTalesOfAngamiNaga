using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Boolean collect = false;
    private Player player = null;

    public Sprite icon;
    public CollectableType type;

    public GameObject collectSign;

    public float collectDistance = 0.25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Player>();
        if (player)
        {
            collect = true;
        }
    }

    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Return)
            && collect == true
            && Vector2.Distance(transform.position, player.transform.position) <= collectDistance
        )
        {
            CollectCollectable();
        }
    }

    // public void CollectCollectable()
    // {
    //     player.inventory.Add(this);
    //     Destroy(this.gameObject);
    // }

    public static event Action CollectableCollected;

    public void CollectCollectable()
    {
        player.inventory.Add(this);
        CollectableCollected?.Invoke();
        Destroy(this.gameObject);
    }
}

public enum CollectableType
{
    NONE,
    CARROT_SEED,
    FLOWER,
    WOOD
}
