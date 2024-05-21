using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchEffect : MonoBehaviour
{
    private Rigidbody2D fish;
    private SpriteRenderer sprite;
    private float thrust = 8f;

    public Sprite fishSprite;

    // Start is called before the first frame update
    void Start()
    {
        fish = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        sprite.sprite = fishSprite;

        fish.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        fish.AddForce(transform.right * Random.Range(-2f, 2f), ForceMode2D.Impulse);
        fish.AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
