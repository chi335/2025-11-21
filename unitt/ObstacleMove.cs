using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // 이동 속도를 위한 변수
    float delta = 0.01f;

    // C# Method & parameter: Ball까지의 거리를 계산하여 출력하는 메서드
    public void TestMethod(string name, int a)
    {
        // "name"을 가진 오브젝트(예: Ball)의 위치와 Obstacle의 위치 사이의 거리를 계산
        GameObject target = GameObject.Find(name);
        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            Debug.Log(name + "까지 거리: " + distance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. TestMethod 호출: 매 프레임마다 Ball과의 거리 측정
        TestMethod("Ball", 0);

        // 2. 장애물 왕복 이동 로직 (Local Position 사용)
        float newXPosition = transform.localPosition.x + delta;
        
        // Local Position을 사용하여 X 위치를 업데이트하고 Y, Z 위치 유지
        transform.localPosition = new Vector3(
            newXPosition,
            transform.localPosition.y,
            transform.localPosition.z
        ); 

        // 3. 경계 조건 확인 및 방향 전환
        if (transform.localPosition.x < -9)
        {
            delta = 0.01f; // 오른쪽으로 이동
        }
        else if (transform.localPosition.x > 9)
        {
            delta = -0.01f; // 왼쪽으로 이동
        }
    }

    // 4. 물체의 충돌 감지 및 반발력 적용 메서드
    // 충돌이 발생하는 순간 한 번 호출됨
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 이름을 콘솔에 출력
        Debug.Log(collision.gameObject.name);

        // 충돌한 오브젝트(collision.gameObject)의 위치에서 현재 오브젝트(Obstacle)의 위치를 뺀다.
        // 이로 인해 방향 벡터는 Obstacle -> collision.gameObject 을 향한다.
        // 우리는 충돌 시 밀어내는 힘을 원하므로, 아래 코드는 Obstacle -> Ball 방향의 반대(Ball -> Obstacle)로 밀어낸다. 
        // Force를 가하는 방향을 명확하게 하려면, (Obstacle 위치 - Ball 위치)를 사용해야 합니다.
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        
        // 방향 벡터를 정규화하고 1000을 곱하여 힘의 크기를 결정
        direction = direction.normalized * 1000f; 
        
        // 충돌한 오브젝트(공)의 RigidBody를 가져와 힘을 가함
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction);
        }
    }
}