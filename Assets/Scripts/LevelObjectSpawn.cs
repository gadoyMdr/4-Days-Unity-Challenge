using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObjetSet
{
    public LevelObject levelObject;
    public int odds;
}

public class LevelObjectSpawn : MonoBehaviour
{
    [SerializeField]
    private List<LevelObjetSet> levelObjetSetList = new List<LevelObjetSet>();
    [SerializeField]
    private float topY;
    [SerializeField]
    private float bottomY;

    private void Start() => StartCoroutine(SpawnObject());
    

    public IEnumerator SpawnObject()
    {
        LevelObject levelObjectToSpawn = GetRandomLevelObject();
        Vector3 spawnPos = Vector3.zero;

        if (levelObjectToSpawn.randomY) spawnPos = GetRandomSpawnPoint();
        else
        {
            if (levelObjectToSpawn.fixedY) spawnPos = new Vector3(transform.position.x, levelObjectToSpawn.transform.position.y, transform.position.z);
            else spawnPos = transform.localPosition;
            if (!levelObjectToSpawn.randomY && !levelObjectToSpawn.fixedY) spawnPos = transform.localPosition;
        }

        Instantiate(levelObjectToSpawn, spawnPos, Quaternion.identity );

        yield return new WaitForSeconds(levelObjectToSpawn.minNextSpawnTime);
        
        StartCoroutine(SpawnObject());
    }

    LevelObject GetRandomLevelObject()
    {
        int random = Random.Range(0, 100);
        int temp = 0;
        foreach(LevelObjetSet l in levelObjetSetList)
        {
            temp += l.odds;
            if (temp > random) return l.levelObject;
        }
        return null;
    }

    Vector3 GetRandomSpawnPoint() => new Vector3(transform.position.x, Random.Range(topY, bottomY));
    

    
}
