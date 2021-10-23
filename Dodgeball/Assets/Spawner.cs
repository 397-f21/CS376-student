using UnityEngine;

/// <summary>
/// Periodically spawns the specified prefab in a random location.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 20;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    /// <summary>
    /// initial start time
    /// </summary>
    public float currentTime = 0;

    /// <summary>
    /// Period the object should wait between spawne
    /// </summary>
    public float timeInterval = 10;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        if(currentTime > 0){
            currentTime -= Time.deltaTime;
            return;
        }

        var randomPosition = SpawnUtilities.RandomFreePoint(FreeRadius);
        Instantiate(Prefab, new Vector3(randomPosition.x,randomPosition.y,0),Prefab.transform.rotation);
        currentTime = timeInterval;
    }
}
