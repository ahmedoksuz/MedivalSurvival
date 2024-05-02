using System;
using System.Collections;
using System.Collections.Generic;
using PufferSoftware.Manager;
using PufferSoftware.Scripts.EventSystem;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    private void Start()
    {
        Push(CustomEvents.OnGameStart);
    }
}