using UnityEngine;
using Unity.Services.Analytics;

public class TrapHitReporter : MonoBehaviour
{
    private TrapInfo trapInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trapInfo = GetComponent<TrapInfo>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player") && trapInfo != null)
        {
            Vector3 pos = transform.position;

            CustomEvent trapHitEvent = new CustomEvent("Trap_Hit")
            {
                { "level", trapInfo.levelName },
                { "trapID", trapInfo.trapID },
                { "trapType", trapInfo.trapType },
                { "positionX", pos.x },
                { "positionY", pos.y }
            };

            AnalyticsService.Instance.RecordEvent(trapHitEvent);
            Debug.Log($"Analytics Sent: {trapInfo.trapID} at {trapInfo.levelName}");
        }
    }
}
