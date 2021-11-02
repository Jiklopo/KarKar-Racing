using System;
using UnityEngine;

namespace Cars
{
	[Serializable]
	public class AxleInfo {
		public WheelCollider leftWheel;
		public WheelCollider rightWheel;
		public Transform leftWheelVisual;
		public Transform rightWheelVisual;
		public bool steering;
		public bool motor;
	}
}