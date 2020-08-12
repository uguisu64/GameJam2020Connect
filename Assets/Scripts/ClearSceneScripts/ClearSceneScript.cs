using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearSceneScript : MonoBehaviour
{
    public Text timeText;

    private void Start()
    {
        timeText.text = GameManageScript.time.ToString("F0") + "s";
    }
}
