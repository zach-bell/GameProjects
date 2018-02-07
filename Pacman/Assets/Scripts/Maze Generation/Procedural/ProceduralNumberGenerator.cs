public class ProceduralNumberGenerator {
	private int currentPosition = 0;
	private string seed;

	public ProceduralNumberGenerator(BaseSeedProvider seedProvider) {
		seed = seedProvider.ProvideSeed();
	}


	public WallDirection GetNextNumber() {
		string currentNum = seed.Substring(currentPosition++ % seed.Length, 1);
		return (WallDirection)int.Parse(currentNum);
	}
}