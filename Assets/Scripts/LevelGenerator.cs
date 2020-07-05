using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private const float SpawnDistanceFromPlayer = 2f;
    [SerializeField] private Transform StartSection;
    [SerializeField] private List<Transform> LevelPartList;
    [SerializeField] private GameObject player;
    Transform lastEndPosition;


    void Awake()
    {
        lastEndPosition = StartSection.Find("SectionEnd");

        for(int i = 0; i < 5; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        if(
            player.transform.position.x + SpawnDistanceFromPlayer
            > lastEndPosition.position.x
        )
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        Transform randomLevelpart = LevelPartList[Random.Range(0, LevelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(randomLevelpart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("SectionEnd");
    }

    private Transform SpawnLevelPart(Transform levelPart, Transform spawnPosition)
    {
        return Instantiate(levelPart, spawnPosition.position, Quaternion.identity);
    }
}
