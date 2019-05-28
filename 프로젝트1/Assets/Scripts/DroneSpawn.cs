using UnityEngine;
using System.Collections;

public class DroneSpawn : MonoBehaviour {
    // drone 의 prefab 주소
	public GameObject drone;
    // Random 을 위한 최대 최소 값 설정
	public float MIN_TIME = 1;
	public float MAX_TIME = 5;
	// Use this for initialization
	void Start () {
        // Drone 을 만들기 위한 코루틴 실행
		StartCoroutine("CreateDrone");
	}
	
	IEnumerator CreateDrone()
	{
        // 어플리케이션이 실행 중인 동안 동작한다.
		while(Application.isPlaying)
		{
            // 랜덤시간을 구하여 그 시간동안 기다리도록 한다.
			float createTime = Random.Range(MIN_TIME, MAX_TIME);
			yield return new WaitForSeconds(createTime);
            // Drone 을 하나 복제 하여 DroneSpawn 의 위치에 생성을 한다.
			Instantiate(drone, transform.position, Quaternion.identity);
		}
	}
}
