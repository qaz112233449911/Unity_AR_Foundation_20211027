using System.Collections;
using System.Collections.Generic;   //�ޥ� ���X API�A�]�t�M�� List
using UnityEngine;
using UnityEngine.XR.ARFoundation;  //�ޥ� Foundation API
using UnityEngine.XR.ARSubsystems;  //�ޥ� Subsystems API

namespace LiangWei.ARFoundation
{
    /// <summary>
    /// �˴��a�O�I���޲z��
    /// �I���a�O��B�z���ʦ欰
    /// �ͦ�����P������m
    /// </summary>
    public class DetechGroundManger : MonoBehaviour
    {
        [Header("�I����n�ͦ�������")]
        public GameObject goDragon;
        [Header("AR �g�u�޲z��"), Tooltip("���޲z���n��b��v�� Origin ����W")]
        public ARRaycastManager arRaycastManager;
        [Header("�ͦ�����n���V��v��������")]
        public Transform traCamera;
        [Header("�ͦ����󭱬۳t��"), Range(0, 100)]
        public float speedLookAt = 3.5f;

        private Transform traDragon;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();     //�M����� = �s�W ���� �M�檫��

        /// <summary>
        /// �ƹ�����PĲ��
        /// </summary>
        private bool inputMouseLeft { get => Input.GetKeyDown(KeyCode.Mouse0); }

        private void Update()
        {
            ClickAndDetechGround();
        }
        /// <summary>
        /// �I���P�˴��a�O
        /// 1. �����O�_�����w����
        /// 2. �N�I���y�Ь���
        /// 3. �g�u�˴�
        /// 4. ����
        /// </summary>
        private void ClickAndDetechGround()
        {
            if (inputMouseLeft)                                                                          // �p�G ���U���w����
            {
                Vector2 positionMouse = Input.mousePosition;                                             // ���o �I���y��
                
                Ray ray = Camera.main.ScreenPointToRay(positionMouse);                                   // �N �I���y�� �ର �g�u
                if (arRaycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))               // �p�G �g�u ������w���a�O����
                {
                    Vector3 positionHit = hits[0].pose.position;                                         // ���o�I�쪺�y��

                    if (traDragon == null)
                    {
                        traDragon = Instantiate(goDragon, positionHit, Quaternion.identity).transform;   // �N����ͦ��b�I�쪺�y�ФW
                        traDragon.localScale = Vector3.one * 0.5f;
                    }
                    else                                                                                 // �_�h ���ͦ��L���� �N��s�y��
                    {
                        traDragon.position = positionHit;
                        DragonLookAtCamera();
                    }                   
                }
            }
        }
        /// <summary>
        /// �ͦ����󭱦V��v��
        /// </summary>
        private void DragonLookAtCamera()
        {
            Quaternion angle = Quaternion.LookRotation(traCamera.position - traDragon.position);             // ���o�V�q
            traDragon.rotation = Quaternion.Lerp(traDragon.rotation, angle, Time.deltaTime * speedLookAt);   // ���׮t��
            Vector3 angleOrigial = traDragon.localEulerAngles;                                               // ���o�y��
            angleOrigial.x = 0;                                                                              // �ᵲ X
            angleOrigial.z = 0;                                                                              // �ᵲ Z
            traDragon.localEulerAngles = angleOrigial;                                                       // ��s����
        }
    }
}
