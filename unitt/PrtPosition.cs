using UnityEngine;

public class PrtPosition : MonoBehaviour
{
    // Start is called before the first frame update
    float startingPoint;
    bool isOver20 = true;  // 20을 넘었는지 체크하는 플래그 (초기값: true)
    bool isOver40 = true;  // 40을 넘었는지 체크하는 플래그 (초기값: true)
    
    void Start()
    {
        // Debug.Log("Start"); // 이전 단계의 Debug.Log는 여기서는 생략 가능합니다.
        startingPoint = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        distance = transform.position.z - startingPoint;
        // Debug.Log("Distance: " + distance); // 이전 단계의 Debug.Log는 여기서는 생략 가능합니다.

        // distance가 40을 넘었을 때 (가장 큰 조건부터 검사)
        if (distance > 40)
        {
            if (isOver40) // 아직 출력하지 않았다면
            {
                Debug.Log("Over 40 distance: " + distance);
                isOver40 = false; // 플래그를 false로 바꿔 다시 출력되지 않게 합니다.
            }
        }
        // distance가 20을 넘었을 때 (40보다는 작지만 20보다는 큽니다)
        else if (distance > 20)
        {
            if (isOver20) // 아직 출력하지 않았다면
            {
                Debug.Log("Over 20 distance: " + distance);
                isOver20 = false; // 플래그를 false로 바꿔 다시 출력되지 않게 합니다.
            }
        }
    }
}