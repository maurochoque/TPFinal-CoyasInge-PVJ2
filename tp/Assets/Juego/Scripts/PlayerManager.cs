using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playersPrefabs;
    [SerializeField] public CharacterNetworkManager hero;
    private int index;

    private void Update() {
        index = PlayerPrefs.GetInt("Select", 0);
        hero.playerPrefab = playersPrefabs[index];
    }
}
