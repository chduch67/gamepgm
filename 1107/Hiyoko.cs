using UnityEngine;

public class Hiyoko : MonoBehaviour
{
    public float power = 6.5f;
    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("DeathZone");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        GetComponent<Rigidbody>().AddForce(direction.normalized * power);
        transform.LookAt(direction);
    }
}
