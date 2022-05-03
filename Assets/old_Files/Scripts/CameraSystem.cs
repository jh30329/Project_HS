using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public float rotateSpeed;
    public float scrollSpeed;
    public float CamHight = 1.0f;

    public Transform pivot;

    private Vector3 newPosition;
    
    [System.Serializable]
    public class SphericalCoordinates
    {
        public float _radius;
        public float _azimuth;
        public float _elevation;
        
        public float _minRadius = 3f;
        public float _maxRadius = 8f;

        public float minAzimuth = 0f;
        private float _minAzimuth;

        public float maxAzimuth = 360f;
        private float _maxAzimuth;

        public float minElevation = 0f;
        private float _minElevation;

        public float maxElevation = 85f;
        private float _maxElevation;
        


        //반지름 함수
        public float radius
        {
            get { return _radius; }
            private set
            {
                _radius = Mathf.Clamp(value, _minRadius, _maxRadius);
            }
        }

        //방위각 함수
        public float azimuth
        {
            get { return _azimuth; }
            private set
            {
                _azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
            }
        }

        //양각 함수

        public float elevation
        {
            get { return _elevation; }
            private set
            {
                _elevation = Mathf.Clamp(value, _minElevation, _maxElevation);
            }
        }

        //현재 카메라 위치의 구면 좌표계를 구함
        public SphericalCoordinates (Vector3 cartesianCoordinate)
        {
            _minAzimuth = Mathf.Deg2Rad * minAzimuth;
            _maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

            _minElevation = Mathf.Deg2Rad * minElevation;
            _maxElevation = Mathf.Deg2Rad * maxElevation;

            radius = cartesianCoordinate.magnitude;
            azimuth = Mathf.Atan2(cartesianCoordinate.z, cartesianCoordinate.x);
            elevation = Mathf.Asin(cartesianCoordinate.y / radius);
            
        }

        //현재 카메라 위치를 직교 좌표계로 변환해 반환
        public Vector3 toCartesian
        {
            get
            {
                float t = radius * Mathf.Cos(elevation);
                return new Vector3(t * Mathf.Cos(azimuth), radius * Mathf.Sin(elevation), t * Mathf.Sin(azimuth));
            }
        }

        //카메라를 구면 좌표계에서 움직임
        public SphericalCoordinates Rotate(float newAzimuth, float newElevation)
        {
            azimuth += newAzimuth;
            elevation += newElevation;
            return this;
        }

        public SphericalCoordinates TranslateRadius(float x)
        {
            radius += x;
            return this;
        }
        
    }

    public SphericalCoordinates sphericalCoordinates;

    void Start()
    {
        sphericalCoordinates = new SphericalCoordinates(transform.position);
        transform.position = sphericalCoordinates.toCartesian + pivot.position;
    }

    private void Update()
    {
       
    }

    void LateUpdate()
    {
        float mh, mv, sw;

        sw = Input.GetAxis("Mouse ScrollWheel") * -1;
        mh = Input.GetAxis("Mouse X") * -1;
        mv = Input.GetAxis("Mouse Y") * -1;

        // 좀더 넓은 시야를 위해 플레이어의 약간 위쪽위치를 설정
        newPosition = new Vector3(pivot.position.x, pivot.position.y + CamHight, pivot.position.z);

        // 카메라 회전
        transform.position
            = sphericalCoordinates.Rotate(mh * rotateSpeed * Time.deltaTime, mv * rotateSpeed * Time.deltaTime).toCartesian + newPosition;

        // 카메라 줌아웃
        transform.position = sphericalCoordinates.TranslateRadius(sw * Time.deltaTime * scrollSpeed).toCartesian + newPosition;

        transform.LookAt(newPosition);
    }
    
}
