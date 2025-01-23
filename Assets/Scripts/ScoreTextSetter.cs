using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextSetter : MonoBehaviour
{
public TextMeshProUGUI scoreText;

private void Update()
{
    scoreText.text = GlobalManager.ConvertNumbersToString(GlobalManager.Instance.score.ToString());
}
}
