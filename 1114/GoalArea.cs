using UnityEngine;

public class GoalArea : MonoBehaviour
{
    public static bool goal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goal = false;
    }

    // 충돌 감지
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            goal = true;
        }
    }
}
