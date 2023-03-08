using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler 
{
    public static event Action<Enemy> AfterKillEnemy;
    public static void CallAfterKillEnemy(Enemy enemy)
    {
        if(AfterKillEnemy != null)
        {
            AfterKillEnemy(enemy);
        }
    }

}
