using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int EnemyTerm = 20;
    private int enemyTermCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (++enemyTermCount >= EnemyTerm)
        {
            Spawn();
            enemyTermCount = 0;
        }
    }

    private void Spawn()
    {
        var enemyPrefab = Resources.Load("Prefabs/EnemyGroup") as GameObject;
        var enemyObject = Instantiate(enemyPrefab);
        enemyObject.transform.position = transform.position + new Vector3(-0.5422525f, 4.445132f, -18.02633f);
    }
}