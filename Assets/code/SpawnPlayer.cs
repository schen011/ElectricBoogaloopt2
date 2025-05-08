using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [TextArea] [SerializeField] List<string> promptList;
    [SerializeField] List<GameObject> characters;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] private Quaternion spawnRotation;
    private GameObject currentCharacter;
    void Awake()
    {
        spawnPosition = new Vector3(-0.16f, 0.1f, 15f);
        spawnRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SpawnNewCharacter();
        }
        
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            NextPlayer();
        }
    }
    
    public void SpawnNewCharacter() 
    {
        // string prompt = promptList[Random.Range(0, promptList.Count - 1)];
        // do prompting
        // do i even need to do that
        
        // currentCharacter = Instantiate(characters[Random.Range(0, characters.Count - 1)], spawnPosition, spawnRotation);
        
        // currentCharacter = characters[Random.Range(0, characters.Count - 1)];
        // currentCharacter.setActive();
        
        // connect?
    }

    public void NextPlayer()
    {
        // delete current player
        SpawnNewCharacter();
    }
}
