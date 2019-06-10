using UnityEngine;
using System.Collections;


public class Drone : MonoBehaviour {
    // 길찾기시스템을 이용하기 위한 변수 선언
	UnityEngine.AI.NavMeshAgent agent;
    // tower 객체를 저장하기 위한 변수
	Transform tower;
    // drone 의 공격 텀을 위한 변수 지정
	public float ATTACK_TIME = 2;
	float attackTime = 0;
    // drone 의 최대 hp
	public int MAX_HP = 3;
    // hp 를 public 으로 선언 하나 inspector 창에 표시 안하기 위한 선언
	[System.NonSerialized]
	public int hp = 0;

    // drone 의 공격 시작 거리
	public float ATTACK_DISTANCE = 1;
	// Use this for initialization
	void Start () {
        // 필요한 컴포넌트와 객체 구하기
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		tower = GameObject.Find("Tower").transform;

        // 길찾기 목적지 지정
		agent.destination = tower.position;

        // hp 및 공격 시간 세팅
		hp = MAX_HP;
		attackTime = ATTACK_TIME;
	}


	void Update()
	{
		// drone 의 공격 범위 안에 들어 왔을 경우 공격 시간에 따라 공격진행
		if(agent.remainingDistance <= ATTACK_DISTANCE)
		{
			attackTime += Time.deltaTime;
			if(attackTime > ATTACK_TIME)
			{
				attackTime = 0;
                try
                {
                    // Tower 에 데미지 입히기
                    Tower.Instance.Damage();
                }
                catch { }
			}
		}
	}
}
