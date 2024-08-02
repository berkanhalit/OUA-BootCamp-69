using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float respawnDelay = 2f;
    public Controller playerController;
    public float gold;
    public Text goldText;
    void Start()
    {
        playerController = FindObjectOfType<Controller>();
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
    }
    public void AddGold(int pointOfGold)
    {
        gold += pointOfGold;

        goldText.text = "Puan: " + gold;

    }
}
