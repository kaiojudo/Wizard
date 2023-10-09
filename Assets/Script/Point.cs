using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Text Score;

    void Update()
    {
        Score.text = "Score: "+ Player.point;
    }
}
