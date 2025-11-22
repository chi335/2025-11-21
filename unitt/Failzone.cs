using UnityEngine.SceneManagement; // SceneManager를 사용하기 위해 필요합니다.
using UnityEngine; // MonoBehaviour를 사용하기 위해 필요합니다.

// 이 코드가 포함될 스크립트 (예: GameManager.cs 또는 RestartGame.cs)
public class GameManager : MonoBehaviour 
{
    // ... 다른 변수와 메서드들 ...

    /// <summary>
    /// 현재 씬을 다시 로드하여 게임을 재시작합니다.
    /// Build Settings (빌드 설정)에서 0번 인덱스에 있는 씬이 로드됩니다.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // ... 다른 메서드들 ...
}