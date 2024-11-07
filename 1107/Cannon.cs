using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;
    public float power;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 마우스 왼쪽 버튼 클릭
        {
            GameObject bullet = LoadBullet();
            
            // 카메라에서 마우스 위치를 향하는 Ray를 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Ray의 방향을 정규화하여 목표 방향 벡터를 구함
            Vector3 dir = ray.direction.normalized;

            // 총알에 물리력 적용 (속도)
            bullet.GetComponent<Rigidbody>().linearVelocity = dir * power;
        }
    }

    GameObject LoadBullet()
    {
        // 총알 프리팹을 인스턴스화하여 생성
        GameObject bullet = Instantiate(prefab) as GameObject;

        // 총알을 발사기 (Cannon) 아래에 자식으로 설정
        bullet.transform.parent = transform;
        // 발사 위치를 (0,0,0)으로 설정 (Cannon의 위치를 기준)
        bullet.transform.localPosition = Vector3.zero;

        return bullet;
    }
}
