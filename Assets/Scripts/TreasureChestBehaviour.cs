using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestBehaviour : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private Sprite openChest;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void Open()
    {
        isOpen = true;
        sr.sprite = openChest;
    }
}
