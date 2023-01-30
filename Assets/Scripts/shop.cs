using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class shop : MonoBehaviour
{
    private BuildManager buildManager;
    //on cree deux blueprint associés aux 2 types de tourelle que l'on peux modifier directement dans unity car
    //ils sont serialized
    public TurretBlueprint standartTurret;
    public TurretBlueprint rocketLuncher;
    public TurretBlueprint nukeLuncher;
    public TurretBlueprint laserBeamer;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Fonction de construction des tourelles standart, appelée qd on clique sur le bouton associé
    public void SelectStandartTurret()
    {
        Debug.Log("Tourrelle standart selectionnée");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    //Fonction de construction des tourelles rockette, appelée qd on clique sur le bouton associé
    public void SelecteRocketLuncher()
    {
        Debug.Log("Tourrelle standart selectionnée");
        buildManager.SelectTurretToBuild(rocketLuncher);
    }

    //Fonction de construction des tourelles rockette, appelée qd on clique sur le bouton associé
    public void SelecteNukeLuncher()
    {
        Debug.Log("Nuke selectionnée");
        buildManager.SelectTurretToBuild(nukeLuncher);
    }

    //Fonction de construction des tourelles laser, appelée qd on clique sur le bouton associé
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser selectrionné");
        buildManager.SelectTurretToBuild(laserBeamer);
    }


}
