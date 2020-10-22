using UnityEngine;

public class DodoEnemyDetector : MonoBehaviour
{
    [SerializeField] bool canAttackRodeur = false;

    DodoAI dodoAI;

    void Start()
    {
        dodoAI = GetComponentInParent<DodoAI>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canAttackRodeur)
        {
            if (!collision.CompareTag("Machibuse") && !collision.CompareTag("Rodeur")) return;
        }
        else
        {
            if (!collision.CompareTag("Machibuse")) return;
        }

        dodoAI.EnemyDetected(collision.transform);
    }
}
