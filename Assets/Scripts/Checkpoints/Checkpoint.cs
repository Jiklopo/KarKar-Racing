using System.Collections.Generic;
using Cars;
using Events;
using UI;
using UnityEngine;

namespace Checkpoints
{
	public class Checkpoint: MonoBehaviour
	{
		[SerializeField] private bool isStart;
		private readonly List<Car> crossedCars = new List<Car>();
		public bool Cross(Car car)
		{
			if (IsFinished(car))
			{
				GameBus.OnLapCompleted.Invoke();
				return true;
			}
			
			if (car == null || crossedCars.Contains(car))
				return false;
			
			crossedCars.Add(car);
			GameBus.OnCheckPointPassed.Invoke(car);
			Debug.Log($"{car.name} crossed {name} at {Time.time} in {transform.position}");
			return true;
		}

		private bool IsFinished(Car car)
		{
			return isStart &&
			       crossedCars.Contains(car) &&
			       car.CheckPointsPassed > 1 &&
			       car.GetType() == typeof(PlayerCarController);
		}
	}
}