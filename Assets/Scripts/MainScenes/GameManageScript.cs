using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManageScript : MonoBehaviour
{

    public GameObject block;
    public Text timeText;

    private List<GameObject> moveBlocks = new List<GameObject>();

    private int blockType;


    public static float time;

    void Start()
    {
        time = 0;
        blockType = 5;
        MakeNewMoveBlocks(Random.Range(0, blockType));
        StartCoroutine(MoveBlocksDown());
    }


    void Update()
    {
        //入力部分
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool canMove = true;

            for (int i = 0; i < moveBlocks.Count; i++)
            {
                if (moveBlocks[i].GetComponent<BlockScript>().CanMove(2) == false)
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                for(int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].transform.position += Vector3.right * 0.64f;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool canMove = true;

            for (int i = 0; i < moveBlocks.Count; i++)
            {
                if (moveBlocks[i].GetComponent<BlockScript>().CanMove(3) == false)
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                for (int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].transform.position += Vector3.left * 0.64f;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool canMove = true;

            for (int i = 0; i < moveBlocks.Count; i++)
            {
                if (moveBlocks[i].GetComponent<BlockScript>().CanMove(1) == false)
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                for (int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].transform.position += Vector3.down * 0.64f;
                }
            }
            else
            {
                for(int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].GetComponent<BlockScript>().SetBlock();
                }
                moveBlocks.Clear();
                MakeNewMoveBlocks(Random.Range(0, blockType));
            }
        }

        //時間計測
        time += Time.deltaTime;
        timeText.text = time.ToString("F0") + "s";
    }

    IEnumerator MoveBlocksDown()
    {
        while (true)
        {
            bool canMove = true;

            for (int i = 0; i < moveBlocks.Count; i++)
            {
                if (moveBlocks[i].GetComponent<BlockScript>().CanMove(1) == false)
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                for (int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].transform.position += Vector3.down * 0.64f;
                }
            }
            else
            {
                for (int i = 0; i < moveBlocks.Count; i++)
                {
                    moveBlocks[i].GetComponent<BlockScript>().SetBlock();
                }
                moveBlocks.Clear();
                MakeNewMoveBlocks(Random.Range(0, blockType));
            }

            yield return new WaitForSeconds(1);
        }
        
    }

    private void MakeNewMoveBlocks(int i)
    {
        switch (i)
        {
            case 0://正方形
                MakeBlock(0, 0);
                MakeBlock(0, 1);
                MakeBlock(1, 0);
                MakeBlock(1, 1);
                break;

            case 1://L字型
                MakeBlock(0, 0);
                MakeBlock(1, 0);
                MakeBlock(2, 0);
                MakeBlock(2, 1);
                break;

            case 2://階段
                MakeBlock(0, 0);
                MakeBlock(1, 0);
                MakeBlock(1, 1);
                break;

            case 3://T字型
                MakeBlock(0, 0);
                MakeBlock(1, 0);
                MakeBlock(1, 1);
                MakeBlock(2, 0);
                break;

            case 4://縦棒
                MakeBlock(0, 0);
                MakeBlock(0, 1);
                MakeBlock(0, 2);
                break;

            default:
                break;
        }
    }

    private void MakeBlock(int x,int y)
    {
        GameObject game = Instantiate(block, new Vector3(x * 0.64f, y * 0.64f + 5.56f, 0), Quaternion.identity);
        game.GetComponent<BlockScript>().gameManager = gameObject;
        moveBlocks.Add(game);
    }
}
