using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요합니다.

// 클래스 이름: RestartGame
public class RestartGame : MonoBehaviour // MonoBehaviour 클래스 내부에 정의되어야 Unity에서 작동합니다.
{
    // 코인 개수를 저장하는 변수
    private int coinCount = 0;

    // Start와 Update는 필요 없지만, 스크립트 구조를 위해 남겨둡니다.
    void Start()
    {
        // 게임 시작 시 코인 개수를 초기화하거나 확인
        Debug.Log("게임 시작! 현재 동전 개수: " + coinCount);
    }
    
    void Update()
    {
        
    }
    
    // 코인을 획득했을 때 호출되는 메서드
    public void GetCoin()
    {
        // 1. 코인 개수를 1 증가
        coinCount++;
        
        // 2. 현재 코인 개수를 콘솔에 출력 (디버깅용)
        Debug.Log("동전 획득! 현재 동전 개수: " + coinCount);
    }

    // ✅ 에러 해결: 메서드 이름을 클래스 이름(RestartGame)과 다르게 변경했습니다.
    // FailZone 또는 UI 버튼 등에서 이 메서드를 호출해야 합니다.
    public void ReloadScene() // 메서드 이름 변경됨 (이전: RestartGame)
    {
        // 빌드 설정(Build Settings)에서 인덱스 0에 있는 씬을 로드합니다.
        SceneManager.LoadScene(0); 
    }

    // RedCoin 획득 등의 이벤트 발생 시 호출될 수 있는 메서드
    public void RedCoinStart()
    {
        // 씬에 있는 모든 장애물을 제거하는 메서드를 호출합니다.
        DestroyObstacles();
    }

    // "Obstacle" 태그가 지정된 모든 게임 오브젝트를 찾아 파괴(제거)합니다.
    void DestroyObstacles()
    {
        // 씬에서 "Obstacle" 태그를 가진 모든 게임 오브젝트를 배열로 찾습니다.
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        // 찾은 모든 장애물을 순회하며 제거(Destroy)합니다.
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }
}