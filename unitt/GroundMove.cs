using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start 함수는 비어 있습니다.
    void Start()
    {
        
    }

    // Update 함수를 수정합니다.
    void Update()
    {
        // 이전 키보드 입력 로직 (주석 처리하거나 삭제합니다)
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));
        //float zRotation = transform.localEulerAngles.z;
        //zRotation = zRotation - Input.GetAxis("Horizontal") * 0.1f;
        //transform.localEulerAngles = new Vector3(10, 0, zRotation);
        
        // --- 새로운 마우스 입력 로직 ---

        // 터치 (모바일) 또는 마우스 왼쪽 버튼 (PC) 입력이 있을 때
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            // 현재 마우스 위치(X좌표)를 콘솔에 출력 (디버깅용)
            Debug.Log("Mouse Down" + Input.mousePosition);
            
            // 마우스 X 위치가 화면 중앙(Screen.width / 2)보다 왼쪽에 있으면
            if (Input.mousePosition.x < Screen.width / 2)
            {
                // Z축 회전을 양의 방향(시계 반대 방향)으로 0.05도씩 증가
                transform.localEulerAngles = new Vector3(
                    10, 
                    0, 
                    transform.localEulerAngles.z + 0.05f
                );
            }
            // 마우스 X 위치가 화면 중앙보다 오른쪽에 있으면
            else
            {
                // Z축 회전을 음의 방향(시계 방향)으로 0.05도씩 감소
                transform.localEulerAngles = new Vector3(
                    10, 
                    0, 
                    transform.localEulerAngles.z - 0.05f
                );
            }
        }
    }
}