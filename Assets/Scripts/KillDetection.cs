﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDetection : MonoBehaviour
{
    public GameObject DeathMenuCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DeathMenuCanvas.SetActive(true);
        }
    }
}
