using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VacoTest
{
    [RequireComponent(typeof(DirectionMover))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _updateTime = 1f;

        private DirectionMover _mover;

        private float currentTime = 0;

        private void Awake()
        {
            _mover = GetComponent<DirectionMover>();
        }

        private void OnEnable()
        {
            currentTime = 0;
        }

        private void Update()
        {
            currentTime += Time.deltaTime;

            if (IsTimeOut())
            {
                currentTime = 0;
                UpdateMover();
            }
        }

        private bool IsTimeOut() => currentTime >= _updateTime;

        private void UpdateMover()
        {
            var direction = new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f)).normalized;
            var speed = Random.Range(1f, 5f);
            _mover.Set(speed, direction);
        }
    }
}
