using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorder = 10f;
    private bool canMove = true;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f; //valeur min et max pour la hauteur de la caméra
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canMove = !canMove;
        }
        if (!canMove)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)// deplacement vers l'avant
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)   // deplacement vers l'arrière
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)// deplacement vers la gauche
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)// deplacement vers la droite
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel"); //zoom et dézoom de la caméra

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 500;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
