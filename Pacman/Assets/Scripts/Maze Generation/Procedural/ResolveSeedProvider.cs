public class ResolveSeedProvider {
	public static BaseSeedProvider Resolve(Difficulty difficulty, int configurable = 50) {
		switch (difficulty) {
		case Difficulty.Easy:
			return new EasySeedProvider();
		case Difficulty.Medium:
			return new MediumSeedProvider();
		case Difficulty.Hard:
			return new HardSeedProvider();
		default:
			return new ConfigurableSeedProvider(configurable);
		}
	}
}