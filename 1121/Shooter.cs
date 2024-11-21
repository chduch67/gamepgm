using UnityEngine;

public class Shooter : ObstacleMove
{
    public GameObject stone;
    // 방향 이동에 필요한 변수
    private float delta = 0.01f; // 초기값 설정
    private float timeCount = 0;

    // 충돌 이벤트 처리
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 Rigidbody를 가지고 있을 경우에만 처리
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 방향 계산
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction = direction.normalized * 1000; // 힘 크기 설정
            rb.AddForce(direction); // 힘 적용
        }
        else
        {
            Debug.LogWarning("충돌한 오브젝트에 Rigidbody가 없습니다.");
        }
    }

    // 매 프레임마다 호출
    void Update()
    {
        // 시간 증가
        timeCount += Time.deltaTime;
        if (timeCount > 3)
        {
           // Debug.Log("돌을 던져라");
            Instantiate(stone, transform.position, Quaternion.identity);
            timeCount = 0;
        }

        // X축 이동 처리
        float newXPosition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);

        // 이동 방향 전환
        if (transform.localPosition.x < -9)
        {
            delta = 0.01f; // 오른쪽으로 이동
        }
        else if (transform.localPosition.x > 9)
        {
            delta = -0.01f; // 왼쪽으로 이동
        }
    }
}
