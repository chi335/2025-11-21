using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Is Trigger가 켜진 Collider에 다른 Collider가 진입했을 때 호출됨
    void OnTriggerEnter(Collider collider)
    {
        // 1. 충돌한 오브젝트의 이름이 "Ball"인지 확인
        if (collider.gameObject.name == "Ball")
        {
            // 2. "GameManager" 오브젝트를 찾아서 "GetCoin" 메서드를 호출하는 메시지를 전송합니다.
            // 이로써 GameManager 스크립트에 있는 코인 카운트가 증가됩니다.
            GameObject.Find("GameManager").SendMessage("GetCoin");

            // 3. 이 스크립트가 붙어 있는 코인 오브젝트 자신을 파괴 (코인 획득)
            Destroy(gameObject);
        }
    }
}