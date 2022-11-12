using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Source.Level
{
    public class LocationCreator
    {
        private List<PartLocation> _partsLocation;

        private Dictionary<GameObject, Vector2> _currentLocation;
        public LocationCreator(List<PartLocation> partLoc)
        {
            _partsLocation = partLoc;
            if(CheckPointFinish() && CheckPointStart()) MadeLocation();
        }

        public Transform PointSpawnPlayer()
        {
            foreach (var point in _partsLocation)
            {
                if (point.IsStart()) return point.PointSpawnPlayer();
            }

            return null;
        }
        
        public Dictionary<GameObject, Vector2> GetLocation() => _currentLocation;

        public Vector2 GetPositionEnd()
        {
            return _currentLocation[GetFinishPoint().BodyLocation()];
        }
        private bool CheckPointStart()
        {
            foreach (var partLoc in _partsLocation)
            {
                if (partLoc.IsStart()) return true;
            }
            return false;
        }

        private bool CheckPointFinish()
        {
            foreach (var partLock in _partsLocation)
            {
                if (partLock.IsFinish()) return true;
            }
            return false;
        }

        private PartLocation GetStartPoint()
        {
            foreach (var point in _partsLocation)
            {
                if (point.IsStart()) return point;
            }

            return null;
        }

        private PartLocation GetFinishPoint()
        {
            foreach (var point in _partsLocation)
            {
                if (point.IsFinish()) return point;
            }

            return null;
        }

        private void MadeLocation()
        {
            var locations = new List<PartLocation>(_partsLocation);
            _currentLocation = new Dictionary<GameObject, Vector2>();
            var startPoint = GetStartPoint();
            var finishPoint = GetFinishPoint();
            locations.Remove(startPoint);
            locations.Remove(finishPoint);
            _currentLocation.Add(startPoint.BodyLocation(), startPoint.BodyLocation().transform.position);
            Random rnd = new Random();
            var positionLast = startPoint.PointEndLocation().transform.position.x;
            int randomIndex = 0; 
            for (int i = 0; i < _partsLocation.Count-2; i++)
            {
                if (locations.Count > 1)
                {
                    randomIndex = rnd.Next(0, locations.Count);
                    Debug.Log(randomIndex);
                }
                else
                {
                    randomIndex = 0;
                }
                var startPointLocation = locations[randomIndex].PointStartLocation().position;
                var endPointLocation = locations[randomIndex].PointEndLocation().position;
                var center = endPointLocation.x - startPointLocation.x;
                center = center / 2;
                _currentLocation.Add(locations[randomIndex].BodyLocation(),
                    new Vector2(positionLast + center, 0));
                positionLast += endPointLocation.x - startPointLocation.x;
                locations.RemoveAt(randomIndex);
            }
            var sizeFinish = finishPoint.PointEndLocation().position.x-finishPoint.PointStartLocation().position.x;
            sizeFinish /= 2;
            var pointSpawnFinish =new Vector2(positionLast
                                              + sizeFinish,
                0);

            _currentLocation.Add(finishPoint.BodyLocation(), pointSpawnFinish);
        }
    }
}
