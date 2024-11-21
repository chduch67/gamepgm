using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailZone : MonoBehaviour
{
    // 트리거 충돌 처리
    void OnTriggerEnter(Collider collider)
 {
 Debug.Log(collider.gameObject.name);
 if (collider.gameObject.name == "Ball")
 {
 //GameObject.Find("GameManager").SendMessage("RestartGame");
 GameObject gm = GameObject.Find("GameManager");
 GameManager gmComponent = gm.GetComponent<GameManager>();
 //GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
 gmComponent.RestartGame();
 }
 }

    // Start는 스크립트가 실행될 때 한 번 호출
    void Start()
    {
    }

    // Update는 매 프레임마다 호출
    void Update()
    {
    }
}
