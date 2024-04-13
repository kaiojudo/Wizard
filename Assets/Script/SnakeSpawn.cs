using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeSpawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D snake)
    {
        if (snake.gameObject.CompareTag("Trap") || snake.gameObject.CompareTag("Platform") || snake.gameObject.CompareTag("Checkpoint"))
        {
            Destroy(this.gameObject);
        }
    }
}
