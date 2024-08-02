using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update

    public int goldpoints;
    private GameManager GameManager;

    public void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            GameManager.AddGold(goldpoints);
            Destroy(this.gameObject);

        }
    }

    
}
