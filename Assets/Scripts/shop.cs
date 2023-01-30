using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class shop : MonoBehaviour
{
    private BuildManager buildManager;
    //on cree deux blueprint associ�s aux 2 types de tourelle que l'on peux modifier directement dans unity car
    //ils sont serialized
    public TurretBlueprint standartTurret;
    public TurretBlueprint rocketLuncher;
    public TurretBlueprint nukeLuncher;
    public TurretBlueprint laserBeamer;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Fonction de construction des tourelles standart, appel�e qd on clique sur le bouton associ�
    public void SelectStandartTurret()
    {
        Debug.Log("Tourrelle standart selectionn�e");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    //Fonction de construction des tourelles rockette, appel�e qd on clique sur le bouton associ�
    public void SelecteRocketLuncher()
    {
        Debug.Log("Tourrelle standart selectionn�e");
        buildManager.SelectTurretToBuild(rocketLuncher);
    }

    //Fonction de construction des tourelles rockette, appel�e qd on clique sur le bouton associ�
    public void SelecteNukeLuncher()
    {
        Debug.Log("Nuke selectionn�e");
        buildManager.SelectTurretToBuild(nukeLuncher);
    }

    //Fonction de construction des tourelles laser, appel�e qd on clique sur le bouton associ�
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser selectrionn�");
        buildManager.SelectTurretToBuild(laserBeamer);
    }


}
