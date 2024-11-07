using UnityEngine;

public class HiyokoCreator : MonoBehaviour
{
    public GameObject obj;  // 객체 생성할 GameObject
    public float interval = 3.0f;  // 객체 생성 간격
    private float time = 0.0f;  // 시간 추적 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // obj가 할당되지 않았다면 경고 메시지를 출력
        if (obj == null)
        {
            Debug.LogError("obj is not assigned in the Inspector. Please assign a GameObject to the obj variable.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // DeathZone이 죽지 않은 상태일 때만 객체를 생성
        if (DeathZone.dead == false)
        {
            time += Time.deltaTime;  // 시간 추적

            // interval이 지났을 때 객체 생성
            if (time >= interval)
            {
                time = 0;  // 시간 초기화

                // obj가 null인지 확인 후 객체를 생성
                if (obj != null)
                {
                    GameObject hiyoko = Instantiate(obj) as GameObject;

                    // 위치 랜덤 설정
                    hiyoko.transform.localPosition = new Vector3(
                        Random.Range(-3.0f, 3.0f),
                        Random.Range(1.0f, 5.0f),
                        Random.Range(17.0f, 20.0f)
                    );

                    // 점수 증가
                    Score.score++;
                }
                else
                {
                    // obj가 null일 경우 경고 출력
                    Debug.LogWarning("obj is missing, cannot instantiate Hiyoko.");
                }
            }
        }
    }
}
