using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayerScript : MonoBehaviour
{
    public static bool state = true;

    private void Start()
    {
        if (state)
        {
            state = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
