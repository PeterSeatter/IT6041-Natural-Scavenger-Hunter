using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public static int CurrentWood;
    public static int CurrentBamboo;
    public TextMeshProUGUI WoodText;
    public TextMeshProUGUI BambooText;

    private void Update()
    {
        WoodText.SetText("Wood: " + CurrentWood.ToString());
        BambooText.SetText("Bamboo: " + CurrentBamboo.ToString());
    }

    public void AddWood(int prAddWood)
    {
        CurrentWood += 1;
        
        Debug.Log("You've got wood " + CurrentWood);
    }

    public void AddBamboo(int prAddBamboo)
    {
        CurrentBamboo += 1;

        Debug.Log("You've got bamboo " + CurrentBamboo);
    }
}
