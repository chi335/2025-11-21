using UnityEngine;
using UnityEngine.UI; // Text 컴포넌트 사용을 위해 필요합니다.

public class Timer : MonoBehaviour
{
    // GoalBlock에서 접근할 수 있는 정적 변수입니다.
    public static float time;

    void Start()
    {
        // 게임 시작 시 시간을 0으로 초기화합니다.
        time = 0;
    }

    void Update()
    {
        // GoalArea.goal이 false일 때만 (즉, 목표 지점에 닿기 전까지만)
        if (GoalArea.goal == false) 
        {
            // 시간에 프레임 간의 시간을 더하여 계속 증가시킵니다.
            time += Time.deltaTime; 
        }

        // --- 텍스트 업데이트 부분 (지침 이미지에 따른 구현) ---
        
        // 시간을 정수로 변환합니다.
        int t = Mathf.FloorToInt(time); 
        
        // 현재 오브젝트에서 Text 컴포넌트를 가져옵니다.
        Text uiText = GetComponent<Text>(); 
        
        // Text 내용을 "Time : 정수값" 형태로 업데이트합니다.
        uiText.text = "Time : " + t.ToString();
    }
}