using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale *= 4;
        }
    }
}
