using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverPlate;
    [SerializeField]
    private Text gameOverText;

    private FuelTank tank;
    private Health health;
    private float initialPlayerPos;
    private int enemiesDestroyed = 0;

    public static GameController Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        tank = player.GetComponent<FuelTank>();
        health = player.GetComponent<Health>();
        gameOverPlate.SetActive(false);

        initialPlayerPos = player.transform.position.x;

        Debug.Assert(Instance == null);
        Instance = this;
    }

    private void Update()
    {
        TryShowGameOver();
    }

    private void TryShowGameOver()
    {
        if (gameOverPlate.activeSelf)
            return;

        if (player == null || !health.Alive() || tank.IsEmpty())
            ShowGameOver();
    }

    private void ShowGameOver()
    {
        gameOverPlate.SetActive(true);

        var distance = player.transform.position.x - initialPlayerPos;
        gameOverText.text = string.Format("Game over!\nDistance: {0}\nEnemies destroyed: {1}", distance, enemiesDestroyed);
    }

    public bool IsGameActive()
    {
        return !gameOverPlate.activeSelf;
    }

    public void OnEnemyDestroyed()
    {
        enemiesDestroyed++;
    }
}
