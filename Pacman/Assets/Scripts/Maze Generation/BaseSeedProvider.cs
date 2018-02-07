using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public abstract class BaseSeedProvider {
	private int seedLength;
	private Random random = new Random();
	private List<string> keys = new List<string>();

	protected BaseSeedProvider(int seedLength) {
		this.seedLength = seedLength;
	}

	public string ProvideSeed() {
		for (int i = 0; i < seedLength; i++) {
			keys.Add(random.Next(1, 5).ToString());
		}

		string seed = string.Join("", keys.ToArray());

		Debug.Log(seed.Length);
		Debug.Log(seed);

		return seed;
	}
}