using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트(Text)를 사용하기 위해 추가
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class GameResult : MonoBehaviour
{
    // 최고 기록을 저장할 변수
    private int highscore;
    
    // Inspector에서 연결할 결과 UI 텍스트 변수들
    public Text resultTime;
    public Text bestTime;
    
    // Inspector에서 연결할 결과 패널 전체 (Result 오브젝트)
    public GameObject parts; // 이 변수 이름은 튜토리얼 슬라이드를 따릅니다.

    void Start()
    {
        // 게임 시작 시 저장된 최고 기록을 PlayerPrefs에서 불러옵니다.
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // 저장된 기록이 있으면 불러옵니다.
            highscore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            // 기록이 없으면 임시로 999 (매우 큰 값)으로 초기화합니다.
            highscore = 999;
        }
        
        // 최고 기록을 UI에 초기 표시합니다.
        bestTime.text = "BestTime : " + highscore;
    }

    void Update()
    {
        // GoalArea에서 goal 변수가 true가 되었을 때만 실행합니다.
        if (GoalArea.goal)
        {
            // 1. 결과 패널 활성화
            parts.SetActive(true); 

            // 2. 최종 시간 계산 및 표시
            int result = Mathf.FloorToInt(Timer.time); // 타이머 시간을 정수로 변환
            resultTime.text = "ResultTime : " + result; 
            
            // 3. 최고 기록 갱신 확인
            if (highscore > result)
            {
                // 현재 기록이 최고 기록보다 빠르면 (작으면) 갱신합니다.
                PlayerPrefs.SetInt("HighScore", result);
                
                // 갱신된 최고 기록을 UI에 표시합니다.
                bestTime.text = "BestTime : " + result + " (New!)";
                highscore = result; // highscore 변수도 업데이트
            }
            // 갱신되지 않은 경우에도 UI를 업데이트하여 현재 최고 기록을 보여줍니다.
            else
            {
                 bestTime.text = "BestTime : " + highscore;
            }
        }
    }
    
    // 재시작 버튼(RetryButton) 클릭 시 호출될 함수
    public void OnRetry()
    {
        // "Main" 씬을 다시 로드합니다.
        SceneManager.LoadScene("Main");
    }
}