using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Round : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject Pawn;

    [SerializeField]
    private GameObject Tank;

    [SerializeField]
    private GameObject Rusher;


    GameObject newPawn;
    GameObject newTank;
    GameObject newRusher;


    bool WaveEnd = false;

    List<GameObject> MonstersAlive = new List<GameObject>();

    GameObject[] MA;

    int RoundNo = 1;

    int loop = 1;

    public float maxSpawnRadius = 17f;
    public float minSpawnRadius = 7f;

    movement player;

    void Start()
    {

        StartCoroutine(Spawn());
        player = gameObject.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        MA = GameObject.FindGameObjectsWithTag("enemy");
        if (MA != null && MA.Count() == 0)
        {
            WaveEnd = true;
        }
    }

    IEnumerator Spawn()
    {

        while (true)
        {
            yield return new WaitUntil(() => WaveEnd);




            for (int i = 0; i < loop; i++)
            {

                if (RoundNo % 3 == 0)
                {
                    newPawn = Instantiate(Pawn, RandomLoc(), Quaternion.identity);
                    newTank = Instantiate(Tank, RandomLoc(), Quaternion.identity);
                    newRusher = Instantiate(Rusher, RandomLoc(), Quaternion.identity);
                }
                else if (RoundNo % 2 == 0)
                {
                    newPawn = Instantiate(Pawn, RandomLoc(), Quaternion.identity);
                    newTank = Instantiate(Tank, RandomLoc(), Quaternion.identity);
                }
                else
                {
                    newPawn = Instantiate(Pawn, RandomLoc(), Quaternion.identity);
                }
            }
            if (RoundNo % 3 == 0)
            {
                loop++;
                RoundNo = 0;
            }

            RoundNo++;

            WaveEnd = false;
            player.Heal();
        }

        Vector3 RandomLoc()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(minSpawnRadius, maxSpawnRadius);
            Vector3 spawnPosition = transform.position + new Vector3(randomDirection.x, 0, randomDirection.y) * randomDistance;
            return spawnPosition;
        }
    }
}