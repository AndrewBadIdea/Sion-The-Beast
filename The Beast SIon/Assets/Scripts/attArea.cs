using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attArea : MonoBehaviour
{
    // Start is called before the first frame update

    public Point txt;
    public int points = 0;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //here if Health != null, get health colldier -> dmg

        EnemyAI enemy = collider.GetComponent<EnemyAI>();

        if (enemy != null)
        {
            enemy.Damage(1);
            points++;
            txt.UpdatePoint(points);
        }
    }

}
