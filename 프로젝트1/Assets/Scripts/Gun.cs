using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour {
	public Transform bulletImpact;
	public Transform explosion;
	ParticleSystem bulletps;
	ParticleSystem explosionPs;

    public Transform crossHair;

    Vector3 originSize;
	void Start()
	{
        originSize = crossHair.localScale * 3.2f;
        if (bulletImpact)
			bulletps = bulletImpact.GetComponent<ParticleSystem>();
		if(explosion)
			explosionPs = explosion.GetComponent<ParticleSystem>();
	}
	// Update is called once per frame
	void Update () {
        // Ray 를 카메라의 위치로 부터 나가도록 만든다.
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        // Ray 의 충돌정보를 저장하기 위한 변수 지정
		RaycastHit hitInfo;
        // Ray 를 쏜다. ray 가 부딪힌 정보는 hitInfo 에 담긴다.
		if(Physics.Raycast(ray, out hitInfo))
		{
            // crosshair 의 위치를 ray 가 부딪힌 곳으로 지정
            crossHair.position = hitInfo.point;
            // crosshair 의 방향이 카메라를 향하고 있도록 지정 (빌보딩)
            crossHair.forward = -1 * ray.direction;
            // crosshair 의 크기를 원래크기와 카메라와 충돌 지점간의 거리를 곱해 줌으로서 구한다.
            crossHair.localScale = originSize * hitInfo.distance;
            
            if (Input.GetButtonDown("Fire1"))
            {
                // 총알파편효과가 있을경우 처리
                if (bulletImpact)
                {
                    bulletImpact.up = hitInfo.normal;
                    bulletImpact.position = hitInfo.point + hitInfo.normal * 0.2f;
                    bulletps.Stop();
                    bulletps.Play();
                }
                // ray 와 부딪힌 객체가 drone 이라면 폭발효과 처리
                if (hitInfo.transform.name.Contains("Drone"))
                {
                    if (explosion)
                    {
                        explosion.position = hitInfo.transform.position;
                        explosionPs.Stop();
                        explosionPs.Play();
                        explosion.GetComponent<AudioSource>().Stop();
                        explosion.GetComponent<AudioSource>().Play();

                    }
                    Destroy(hitInfo.transform.gameObject);
                }
                // 총소리는 언제든 실행 되도록 처리
                if (bulletImpact)
                {
                    bulletImpact.GetComponent<AudioSource>().Stop();
                    bulletImpact.GetComponent<AudioSource>().Play();
                }
            }
		}
	}
}
