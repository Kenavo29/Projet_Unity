using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on crée une classe ou on reference toutes les stats du joueur
public class PlayerStats : MonoBehaviour
{
    public static int lives = 20;
    public static int money;
    public int startMoney = 400;

    //on met a jour les valeurs des stats à chaque changement de scene
    public void Start()
    {
        money = startMoney;
    }
}
