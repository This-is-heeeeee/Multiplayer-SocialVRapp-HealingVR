using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tower : MonoBehaviour {
    // Tower 의 싱글톤 객체를 선언
	public static Tower Instance;

    // Tower 의 체력 선언
	public int MAX_HP = 10;
	int hp = 0;
    // 피격시 효과 시간
    public float dieTime = 0.2f;
    // 피격효과객체
	public GameObject die;

    // 싱글톤 구현
	void Awake()
	{        
		if(Instance == null)
			Instance = this;
	}

	void Start()
	{
        // 체력세팅        
		hp = MAX_HP;
	}

    // 피격시 처리 함수
	public void Damage()
	{
		hp--;
        // hp 가 다 소모 됐을 경우 재 시작하도록 선언
		if(hp <= 0)
		{
            SceneManager.LoadScene(0);
        }
        else
        {
            // 피격처리 코루틴 실행 (기존에 진행되던 코루틴은 제거)
            StopAllCoroutines();
            StartCoroutine("DamageProcess");
        }
	}
    // 피격처리를 위한 코루틴함수
    IEnumerator DamageProcess()
    {
        // 피격처리 효과 처리
        die.SetActive(true);
        yield return new WaitForSeconds(dieTime);
        die.SetActive(false);
    }
}
