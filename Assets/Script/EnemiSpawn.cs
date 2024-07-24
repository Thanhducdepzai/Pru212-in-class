using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiSpawn : MonoBehaviour
{
    [SerializeField] private Sprite targetSprite;
    [SerializeField] private BoxCollider2D cd;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private int poolSize = 5;
    [SerializeField]
    private float maxHealth = 3f;

    private float timer;
    private Queue<GameObject> enemyPool;
    private List<GameObject> activeEnemies;

    private void Start()
    {
        enemyPool = new Queue<GameObject>();
        activeEnemies = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newEnemy = Instantiate(targetPrefab);
            newEnemy.SetActive(false);
            enemyPool.Enqueue(newEnemy);
        }
    }

    void Update()
    {
        if (enemyPool.Count > 0 || activeEnemies.Count < poolSize * 2)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = cooldown;
                GameObject newTarget = GetEnemyFromPool();

                float randomX = Random.Range(cd.bounds.min.x, cd.bounds.max.x);
                newTarget.transform.position = new Vector2(randomX, transform.position.y);
                newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite;
                newTarget.SetActive(true);

                // Ensure the health bar is updated correctly
                CircleController controller = newTarget.GetComponent<CircleController>();
                if (controller != null)
                {
                    controller.InitializeHealth(maxHealth);
                }

                activeEnemies.Add(newTarget);
            }
        }
    }

    private GameObject GetEnemyFromPool()
    {
        if (enemyPool.Count > 0)
        {
            return enemyPool.Dequeue();
        }
        else if (activeEnemies.Count < poolSize * 2)
        {
            return Instantiate(targetPrefab);
        }
        else
        {
            return null;
        }
    }

    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        activeEnemies.Remove(enemy);
        enemyPool.Enqueue(enemy);
    }
}
