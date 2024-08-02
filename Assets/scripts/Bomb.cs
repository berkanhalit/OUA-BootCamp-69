using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // public Animator animator;
    private GameManager gameManager;
    [SerializeField] private float expDelay = 0.5f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        //StartCoroutine
        if(other.tag == "Player")
        {
            StartCoroutine("AnimateAndWait");
            Destroy(this.gameObject);
            gameManager.Respawn();
        }
        //Destroy Object
        //gameManager.Respawn()
        
    }
    public IEnumerator AnimateAndWait()
    {
        // Animasyon �al��s�n de�i�kene atad���m�z.
        yield return new WaitForSeconds(expDelay);
    }
}
