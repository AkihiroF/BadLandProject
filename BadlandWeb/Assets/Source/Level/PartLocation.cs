using System;
using UnityEngine;

namespace Source.Level
{
    public class PartLocation : MonoBehaviour
    {
        [SerializeField] private GameObject bodyLocation;
        [SerializeField] private Transform pointStartLocation;
        [SerializeField] private Transform pointEndLocation;
        [SerializeField] private Transform pointSpawnPlayer;
        [SerializeField] private bool isStart;
        [SerializeField] private bool isFinish;
        
        
        public GameObject BodyLocation() => bodyLocation;
        public Transform PointStartLocation() => pointStartLocation;
        public Transform PointEndLocation() => pointEndLocation;
        public Transform PointSpawnPlayer() => pointSpawnPlayer;
        public bool IsStart() => isStart;
        public bool IsFinish() => isFinish;
    }

}
