using UnityEngine;

public class GoalArea : MonoBehaviour
{
    // 목표 지점에 도달했는지 여부를 저장하는 정적(static) 변수입니다.
    // 정적 변수이므로 다른 스크립트(GoalBlock)에서 이 값을 읽거나 변경할 수 있습니다.
    public static bool goal;

    void Start()
    {
        // 게임 시작 시 goal 변수를 false로 초기화합니다.
        goal = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        // 충돌한 오브젝트의 태그가 "Player"인지 확인합니다.
        if (col.gameObject.tag == "Player")
        {
            // 플레이어가 목표 지점에 닿으면 goal 변수를 true로 설정합니다.
            goal = true;
        }
    }
}