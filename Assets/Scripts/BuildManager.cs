using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // on crée une instance de game manager visible par tout le monde
    #region Singleton
    public static BuildManager instance;

    private void Awake()    
    {
        if(instance != null)
        {
            Debug.LogError("Il y a deja un build manager dans la scene!");
            return;
        }
        instance = this;
    }
    #endregion


    public GameObject standardTurretPrefab;
    public GameObject rocketLuncherPrefab;
    public GameObject nukeLuncherPrefab;
    public GameObject buildEffect;


    private TurretBlueprint turretToBuild;

    //On selection la tourelle a construire et on assigne cette tourelle dans la variable turretToBuild
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        
    }
    public bool moneyOk()
    {
        bool a = PlayerStats.money >= turretToBuild.cost;
        return a;
    }
    //Permet de savoir si on a selectionné une tourelle
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }


     //public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
    //Fonction permettant la construction de la tourelle et les verifications associées
    public void BuildTurretOn(Node node)
    {
        int a = PlayerStats.money;
        //Verification que le joueur a assez d'argent
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'argent");
            return;
        }

        //on paie le cout de la tourelle
        PlayerStats.money -= turretToBuild.cost;
        Debug.Log("Objet acheté, il vous reste" + PlayerStats.money);

        //Construction de la tourelle
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position + node.positionOffset, Quaternion.identity);
        Destroy(effect, 1f);
    }


}
