using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FrontColliderScript : MonoBehaviour
{

    public GameObject male;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Imortal" || collision.tag == "Block")
        {
            male.GetComponent<MaleScript>().HitOthers();
        }
    }

}
