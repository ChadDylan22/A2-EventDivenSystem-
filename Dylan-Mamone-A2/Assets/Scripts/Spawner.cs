using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    //defines what is to be spawned, and creates variable for spawn chance.
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;
//defines max and min spawn rate.
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    } 

    private void OnDisable()
    {
        CancelInvoke();
    }
    // sets the spawn chance as a random value, tells obstacle to spawn if the spawn chance value number is lower then an obstacles set spawn chance.
    private void Spawn() 
    {
        float spawnChance = Random.value;
        foreach (var obj in objects) 
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
