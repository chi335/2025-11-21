# 🏃‍♂️ Unity 3D 프로젝트 – RUN

Unity로 제작한 **RUN 게임 프로젝트**의 구성, 스테이지 제작 과정, 캐릭터 설정, 주요 스크립트, 게임 시스템 구현 내용을 정리한 문서입니다.

---

## 📌 프로젝트 및 씬 설정

### 1. 프로젝트 생성
- Unity Hub에서 **3D 프로젝트** 생성  
  → 프로젝트명: **RUN**

### 2. 씬 구성
- 기본 씬 `SampleScene` → **Main**으로 이름 변경

---

## 📦 에셋 임포트

### Standard Assets Import
Asset Store에서 **Standard Assets** 다운로드 후 아래 모듈만 임포트:

- Cameras  
- Characters  
- CrossPlatformInput  
- Prototyping  
- Utility  

### 추가 에셋
- **Yughues Free Metal Materials**  
  → 바닥, 벽, 장애물 텍스처 적용

---

## 🏗 스테이지 구성

Prototyping 에셋을 활용하여 다음 오브젝트 배치:

- Floor1 ~ Floor4  
- Block, BigBlock  
- Wall1, Wall2  
- Pillar  

각 오브젝트의 Transform(위치/회전/크기)을 조절하여 스테이지 구성.

---

## 🧍 캐릭터 및 카메라 설정

### Player 설정
- `ThirdPersonController`를 씬에 배치  
- 오브젝트 이름: **Player**  
- 태그: **Player**

### 카메라 설정
- `Multipurpose CameraRig` 배치  
- CameraRig → Player를 Target으로 설정  
→ 캐릭터 따라오는 카메라 구현

---

## 🎨 비주얼 및 조명 효과

### 머티리얼
- Metal Materials를 사용하여 바닥, 벽, 장애물 외관 변경

### 조명
- Directional Light 밝기 낮춤  
- Spotlight, Pointlight 추가하여 분위기 강화

### 배경음악
- Pillar에 **Audio Source** 추가 후 BGM 연결

---

## 🧩 게임 로직 및 UI 구성

### Trigger 오브젝트
- **OutArea**: 추락 판정  
- **GoalArea**: 목표 도착  
→ Collider의 **Is Trigger** 활성화 필요

### UI 구성
- `TimeText`(타이머)  
- `ResultTitle`, `ResultTimeText`, `BestTimeText`  
- `RetryButton`  
- 스크립트: `Timer`, `GameResult`

---

# 🔧 기본 오브젝트 및 스크립트

## Ground 제작
1. `Cube` 생성  
2. 이름: **Ground**  
3. Transform 조절  
4. Material 생성 → 색상 변경 후 Ground에 적용

---

## PrtPosition.cs — 이동 거리 출력

```csharp
using UnityEngine;

public class PrtPosition : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        Debug.Log("이동 거리: " + distance);

        if (distance > 10f)
        {
            Debug.Log("10m 이상 이동!");
        }
    }
}
```

---
# 🎮 주요 스크립트 및 게임 메커니즘

## BallMove.cs — 오브젝트 이동
transform.Translate(Vector3.forward * Time.deltaTime * 5f);

## RadiusChange.cs — 충돌체 크기 변경
GetComponent<SphereCollider>().radius = 2f;

## 🎥 CameraFollow.cs — 카메라 따라가기
public Transform target;
public Vector3 offset;

void LateUpdate()
{
    transform.position = target.position + offset;
}

## 🎮 입력 및 이동
### GroundMove.cs — 회전
float h = Input.GetAxis("Horizontal");
transform.Rotate(0, h * 100f * Time.deltaTime, 0);

### BallJump.cs — 점프
if (Input.GetKeyDown(KeyCode.Space))
{
    rb.AddForce(Vector3.up * 300f);
}

## 🚧 ObstacleMove.cs — 장애물 이동
public float speed = 3f;

void Update()
{
    transform.Translate(Vector3.left * speed * Time.deltaTime);
}

### 충돌 시 반대 방향으로 튕기기
void OnCollisionEnter(Collision col)
{
    rb.AddForce(Vector3.back * 200f);
}

## 🕹 게임 시스템 구현
### 🧠 GameManager 기능
- 공이 추락하면 게임 재시작
- 코인 획득 시 점수 증가
- 게임 전체 흐름 관리

### 🪙 CoinTrigger.cs — 코인 획득
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        GameManager.instance.AddCoin();
        Destroy(gameObject);
    }
}

### RedCoinItem.cs — 장애물 전체 제거
GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");

foreach (var o in obs)
{
    Destroy(o);
}

## 🪨 투사체 시스템
### Shooter.cs — 돌 발사
public GameObject stonePrefab;
public float interval = 2f;

void Start()
{
    InvokeRepeating("Shoot", 1f, interval);
}

void Shoot()
{
    Instantiate(stonePrefab, transform.position, Quaternion.identity);
}

### Stone.cs — Ball을 향해 이동 & 충돌 처리
void Update()
{
    transform.position = Vector3.MoveTowards(
        transform.position,
        target.position,
        speed * Time.deltaTime
    );
}

void OnCollisionEnter(Collision col)
{
    if (col.gameObject.CompareTag("Player"))
    {
        GameManager.instance.Restart();
    }
}

