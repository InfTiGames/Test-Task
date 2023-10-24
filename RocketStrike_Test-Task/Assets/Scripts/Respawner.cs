using System.Collections;
using UnityEngine;

public class Respawner : MonoBehaviour {

    private SpawnPlayers _spawnPlayers;
    private const float TimeToRespawn = 3f;

    private void Start() => _spawnPlayers = GetComponent<SpawnPlayers>();

    private void OnEnable() => DeathHandler.OnPlayerDead += BeginRespawn;

    private void OnDisable() => DeathHandler.OnPlayerDead -= BeginRespawn;

    /// <summary>
    /// Starts Respawn() coroutine
    /// </summary>
    private void BeginRespawn() => StartCoroutine(Respawn());

    /// <summary>
    /// Calls SpawnPlayer() method from SpawnPlayers class
    /// </summary>
    /// <returns></returns>
    private IEnumerator Respawn() {
        yield return new WaitForSeconds(TimeToRespawn);
        _spawnPlayers.SpawnPlayer();
    }
}