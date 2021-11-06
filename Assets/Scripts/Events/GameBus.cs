using System;

namespace Events
{
	public static class GameBus
	{
		public static Action OnGamePaused;
		public static Action<Car> OnCheckPointPassed;
		public static Action OnLapCompleted;
	}
}