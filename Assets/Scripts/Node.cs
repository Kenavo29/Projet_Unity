using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // Declaration des variables

    //Coleur au survol
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    //Decalage de position pour le placement des tourelles
    public Vector3 positionOffset;
    //Variable permettant de stocker la tourelle placée sur la node
    public GameObject turret;
    //Variable stockant le composant du renderer
    private Renderer rend;
    //Variable stockant la couleur de base de la node pour pouvoir la restaurer apres le survol
    private Color startColor;
    //on declare un build manager pour pouvoir acceder aux fonction et methodes de la classe
    private BuildManager buildManager;





    private void Start()
    {
        rend = GetComponent<Renderer>(); //on recupère le renderer de la node
        startColor = rend.material.color; // on stock la couleur de la node dans la variable

        buildManager = BuildManager.instance;
    }


    private void OnMouseEnter()  // qd la souris passe dessus
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.moneyOk())
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown() // construction tourelle qd on clique
    {
        //Test si une tourelle est selectionnée
        if (!buildManager.CanBuild)
        {
            return;
        }
        //Si la souris est au dessus du shop ou autre game object (type menu etc...)
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)  // test si la case est occupée
        {
            Debug.Log("Deja une tourelle ici");
            return;
        }
        //contruction
        buildManager.BuildTurretOn(this);


    }
}
