using System.Collections;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spwansPoint;
    [SerializeField] private float timeBetween = 2f;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

  private  IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetween);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform transpoint = spwansPoint[Random.Range(0, spwansPoint.Length)];
            Instantiate(enemy, transpoint.position, Quaternion.identity);
        }
    }
    
}
