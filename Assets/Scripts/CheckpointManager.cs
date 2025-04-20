using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Checkpoint lastestCheckpoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        lastestCheckpoint = checkpoint;
    }

    public Vector3 GetRespawnPosition()
    {
        if (lastestCheckpoint != null)
            return lastestCheckpoint.GetPosition();
        else
            return Vector3.zero;
    }
}
