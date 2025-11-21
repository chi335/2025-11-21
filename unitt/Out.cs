using UnityEngine;
using UnityEngine.SceneManagement; 

public class Out : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        // 충돌한 오브젝트의 태그가 "Player"인지 확인합니다.
        if (col.gameObject.tag == "Player")
        {
            // 현재 활성화된 씬을 다시 로드합니다.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}