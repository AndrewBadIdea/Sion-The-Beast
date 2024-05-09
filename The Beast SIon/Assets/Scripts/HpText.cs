using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpText : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text textHp;
    void Start()
    {
        textHp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHp(int hp)
    {
        textHp.text = "Current Health : " + hp;
    }
}
