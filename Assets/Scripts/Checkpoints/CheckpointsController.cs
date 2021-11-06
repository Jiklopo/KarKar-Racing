using System.Collections.Generic;
using System.Linq;
using Cars;
using Events;
using UI;
using UnityEngine;

namespace Checkpoints
{
	public class CheckpointsController : MonoBehaviour
	{
		public static CheckpointsController Instance { get; private set; }
		public int PlayerPos => playerIndex + 1;
		private int playerIndex;
		private List<Transform> checkpoints = new List<Transform>();
		private List<Car> cars = new List<Car>();
		private CarComparer carComparer = new CarComparer();
		private PlayerCarController playerCar;
		
		private void Awake()
		{
			if (Instance != null)
				Destroy(this);

			Instance = this;
			foreach (Transform child in transform)
				checkpoints.Add(child);

			cars.AddRange(FindObjectsOfType<Car>());
			playerCar = FindObjectOfType<PlayerCarController>();
			GameBus.OnCheckPointPassed += OnCheckPointPassed;
			OnCheckPointPassed(cars[0]);
		}

		private void OnCheckPointPassed(Car car)
		{
			if (!cars.Contains(car))
				cars.Add(car);
			
			cars.Sort(carComparer);
			playerIndex = cars.IndexOf(playerCar);
		}

		public Transform GetNextCheckpoint(Transform currentCheckpoint)
		{
			return GetNextCheckpoint(checkpoints.IndexOf(currentCheckpoint));
		}

		public Transform GetNextCheckpoint(int currentCheckPoint)
		{
			var nextCheckPointIndex = GetNextCheckpointIndex(currentCheckPoint);
			return checkpoints[nextCheckPointIndex];
		}

		private int GetNextCheckpointIndex(int currentIndex)
		{
			return (currentIndex + 1) % checkpoints.Count;
		}
	}

	public class CarComparer : IComparer<Car>
	{
		public int Compare(Car x, Car y)
		{
			return y.CheckPointsPassed - x.CheckPointsPassed;
		}
	}
}