using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextSetter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = GlobalManager.ConvertNumbersToString(GlobalManager.Instance.levelTimer.ToString("00.0"));
    }
    
}
