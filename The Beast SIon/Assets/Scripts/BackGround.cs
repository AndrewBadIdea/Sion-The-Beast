using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Pause pause;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.PauseAction();

        }
    }
}
