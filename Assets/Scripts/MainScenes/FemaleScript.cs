using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleScript : MonoBehaviour
{
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Male")
        {
            gameManager.GetComponent<ChangeSceneScript>().ToClearScene();
        }
    }
}
