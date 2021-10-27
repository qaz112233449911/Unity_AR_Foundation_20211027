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
        public GameObject goSpawn;
        [Header("AR �g�u�޲z��"), Tooltip("���޲z���n��b��v�� Origin ����W")]
        public ARRaycastManager arRaycastManager;

        private Transform traSpawn;
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
            if (inputMouseLeft)
            {
                Vector2 positionMouse = Input.mousePosition;

                print("�I���y�� : " + positionMouse);
            }
        }
    }
}
