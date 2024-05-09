using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text textScore;
    void Start()
    {
        textScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void UpdatePoint(int Points)
    {
        textScore.text = "Score : " + Points;
    }
}
