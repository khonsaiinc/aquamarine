using UnityEngine;

public class DisableTalking : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2DTakeda;

    [SerializeField] CashierCounter cashierCounter;
    public bool changeShift = true;

    void Start()
    {
        if(cashierCounter == null)
        {
            return;
        }
    }

    void Update()
    {
        if(cashierCounter != null)
        {
            cashierCounter.isStartEventday1 = changeShift;
        }
    }

    public void DisableTirgger()
    {
        boxCollider2DTakeda.enabled = false;
    }
}
