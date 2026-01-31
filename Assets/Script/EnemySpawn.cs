using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] SkeletonHead;
    Vector3 SpawnPosition;
    private void Start()
    {
        StartCoroutine(EnemySpawner());
    }


    IEnumerator EnemySpawner()
    {
        while (true)
        {
            int SpawnNumber = Random.Range(0, 2);
            GameObject SpawnHead = SkeletonHead[SpawnNumber];

            int MainPosRandom = Random.Range(0, 2);
            float[] positions = { -40f, 40f };
            
            if(MainPosRandom == 0)
            {
                SpawnPosition = new Vector3(Random.Range(-40f, 40f), Random.Range(2f, 16f), positions[Random.Range(0,2)]);
            }

            else
            {
                SpawnPosition = new Vector3(positions[Random.Range(0, 2)],Random.Range(2f,16f),Random.Range(-40f,40f));
            }

            Instantiate(SpawnHead, SpawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(2);

        }



    }
}
