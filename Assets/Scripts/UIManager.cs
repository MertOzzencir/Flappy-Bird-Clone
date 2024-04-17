using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI speedPenaltyText;



    private void Update()
    {
        speedPenaltyText.text = "SPEED PENALTY: " + PlayerControl.inst.speedPenalty.ToString("F2");
        scoreText.text = "SCORE: " + PlayerControl.inst.score;
    }

}
