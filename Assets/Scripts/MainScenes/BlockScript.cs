using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    private bool placed;

    public GameObject gameManager;
    
    void Start()
    {
        placed = false;
    }

    public void SetBlock()
    {
        placed = true;
    }

    public bool GetPlaced()
    {
        return placed;
    }
    
    //iは下向きなら1 右向きなら2 左向きなら3
    public bool CanMove(int i)
    {
        RaycastHit2D hit;

        switch (i)
        {
            case 1:
                hit = Physics2D.Raycast(transform.position + Vector3.down * 0.64f, Vector3.back, 10);
                break;

            case 2:
                hit = Physics2D.Raycast(transform.position + Vector3.right * 0.64f, Vector3.back, 10);
                break;

            case 3:
                hit = Physics2D.Raycast(transform.position + Vector3.left * 0.64f, Vector3.back, 10);
                break;

            default:
                return false;
        }

        if (hit.collider)
        {
            if (hit.collider.tag == "Block")
            {
                bool a = hit.collider.gameObject.GetComponent<BlockScript>().GetPlaced();
                return !a;
            }
            else if (hit.collider.tag == "Imortal")
            {
                return false;
            }
            else if (hit.collider.tag == "Male" || hit.collider.tag == "Female")
            {
                gameManager.GetComponent<ChangeSceneScript>().ToGameOverScene();
            }
        }

        return true;
    }
}
