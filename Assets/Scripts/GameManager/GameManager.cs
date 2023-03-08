using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : SingletonMonobehavior<GameManager>
{
    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    [SerializeField] private TextMeshProUGUI textScoreKilledNumber;

    public void UpdateScore(Score score)
    {
        textScoreKilledNumber.text = "Killed: " + score.killedEnemyNumber;
    }
}
