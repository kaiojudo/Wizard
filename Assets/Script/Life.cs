using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Text life;
    // Start is called before the first frame update
    private void Update()
    {
        life.text = "X " + Player.life;
    }
}
