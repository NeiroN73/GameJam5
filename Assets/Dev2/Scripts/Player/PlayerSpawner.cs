using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _spawnPointPlayer;

    private void Start()
    {
        //SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Player player = Instantiate(_playerPrefab, _spawnPointPlayer.position, Quaternion.identity);

        //CameraMovement camera = Camera.main.GetComponent<CameraMovement>();
        //camera.Initialize(player);

        UI ui = FindObjectOfType<UI>();

        CinemachineVirtualCamera virtCam = FindObjectOfType<CinemachineVirtualCamera>();
        virtCam.Follow = player.transform.GetChild(0);

        DialogueSystem dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
}