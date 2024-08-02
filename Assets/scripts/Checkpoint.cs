using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour

{

    public Sprite blueFlag;
    public Sprite whiteFlag;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool checkPointReached = false; 



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             checkPointReached = true;
            spriteRenderer.sprite = whiteFlag;
        }
    }
}
