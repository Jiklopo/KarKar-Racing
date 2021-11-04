using System.Collections.Generic;
using UnityEngine;

namespace Checkpoints
{
	public class CheckpointsController : MonoBehaviour
	{
		[SerializeField] private List<Transform> checkpoints = new List<Transform>();
		public static CheckpointsController Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null)
				Destroy(this);

			Instance = this;
			foreach (Transform child in transform)
			{
				checkpoints.Add(child);
			}
			
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
}