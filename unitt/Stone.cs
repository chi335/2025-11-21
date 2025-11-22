using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 target;
    // Start is called before the first frame update
    void Start() 
    {
        // Ball 오브젝트의 현재 위치를 타겟으로 지정
        // 주의: "Ball" 오브젝트가 Start 시점에 씬에 있어야 합니다.
        GameObject ball = GameObject.Find("Ball");
        if (ball != null)
        {
             target = ball.transform.position; 
        }
    }

    // Update is called once per frame
    void Update() 
    {
        // 타겟 방향으로 초당 0.01f의 속도로 이동
        transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
        
        // Z축을 기준으로 매 프레임 5도씩 회전
        transform.Rotate(new Vector3(0, 0, 5)); 
    }

    void OnTriggerEnter(Collider collider) 
    {
        Debug.Log(collider.gameObject.name);

        if (collider.gameObject.name == "Ball")
        {
            // 1. GameManager 오브젝트를 찾습니다.
            GameObject gmObject = GameObject.Find("GameManager");

            if (gmObject != null)
            {
                // 2. GameManager 오브젝트에서 RestartGame (이전 스크립트의 클래스 이름) 컴포넌트를 가져옵니다.
                // ⚠️ 에러 방지를 위해 컴포넌트 이름에 'RestartGame' 스크립트 이름을 사용했습니다.
                RestartGame gmComponent = gmObject.GetComponent<RestartGame>(); 

                if (gmComponent != null)
                {
                    // 3. 에러를 피하기 위해 수정했던 'ReloadScene' 메서드를 호출합니다.
                    gmComponent.ReloadScene();
                }
                else
                {
                    Debug.LogError("GameManager 오브젝트에 'RestartGame' 컴포넌트가 부착되어 있지 않습니다.");
                }
            }
            else
            {
                Debug.LogError("'GameManager' 이름의 오브젝트를 찾을 수 없습니다.");
            }
        }
    }
}