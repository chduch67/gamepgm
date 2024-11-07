using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static bool dead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hiyoko")
        {
            UIContoller.gameOver = true;
            dead = true;    
            }
    }
}
