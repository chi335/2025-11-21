using UnityEngine;

public class RedCoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌 감지 메서드 (Is Trigger가 켜진 Collider에 진입했을 때 호출됨)
    void OnTriggerEnter(Collider collider)
    {
        // 1. 충돌한 오브젝트의 이름이 "Ball"인지 확인
        if (collider.gameObject.name == "Ball")
        {
            // 2. "GameManager" 오브젝트를 찾아서 "RedCoinStart" 메서드를 호출하는 메시지를 전송
            // 이 방식은 "GameManager" 오브젝트에 해당 메서드가 정의되어 있어야 작동합니다.
            GameObject.Find("GameManager").SendMessage("RedCoinStart");
            
            // 3. 이 코인 아이템(RedCoin) 자신을 파괴
            Destroy(gameObject);
        }
    }
}