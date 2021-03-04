using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestBehaviour : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private Sprite openChest;
    [SerializeField] private GameObject loot;

    private SpriteRenderer sr;
    private float spawnTimer = 0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (isOpen)
        {
            spawnTimer += Time.fixedDeltaTime;
            if (spawnTimer >= 0.1f)
            {
                spawnTimer = 0f;
                GameObject newLoot = Instantiate(loot, transform);
                newLoot.transform.position = newLoot.transform.position + new Vector3(0, 0, -0.1f); // move them in front of the chest
                newLoot.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1000)); // set its initial velocity
            }
        }
    }

    public void Open()
    {
        isOpen = true;
        sr.sprite = openChest;
    }
}
