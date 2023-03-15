using System.Data;
using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace AmongUsCounter; 

public static class Program {

	public static void Main(string[] args) {
		string execPath = AppDomain.CurrentDomain.BaseDirectory;
		
		if (args.Contains("--small") || args.Length == 0) {
			using (Image<Rgba32> image = Image.Load<Rgba32>(Path.Join(execPath, "amongustest.png"))) {
				int count = 0;
				for (int x = 0; x < image.Height; x++) {
					for (int y = 0; y < image.Width; y++) {
						if (CheckForAmongUsCharacter(image, y, x)) {
							count++;
							y += 3;
						}
					}
				}

				Console.WriteLine($"Small count: {count}");
				image.Dispose();
			}
		}

		if (args.Contains("--big") || args.Length == 0) {
			using (Image<Rgba32> image =
			       Image.Load<Rgba32>(Path.Join(execPath, "bigimg.png"))) {
				int count = 0;
				for (int x = 0; x < image.Height; x++) {
					for (int y = 0; y < image.Width; y++) {
						if (CheckForAmongUsCharacter(image, y, x)) {
							count++;
						}
					}
				}

				Console.WriteLine($"Big count: {count}");
				image.Dispose();
			}
		}
	}


	private static bool CheckForAmongUsCharacter(Image<Rgba32> image, int width, int height) {
		if (height < 0 || width < 0 || height >= image.Height || width >= image.Width) {
			return false;
		}

		foreach (byte[,] pat in Pattern.GetPatternList()) {
			int patternX = pat.GetLength(0);
			int patternY = pat.GetLength(1);

			// Check if it would be out of bounds with pattern sizes
			if (width + patternY > image.Width || height + patternX > image.Height)
				continue;

			// Find out suit and visorColor
			Rgba32 suitColor = new Rgba32(0,0,0,0);
			Rgba32 visorColor = new Rgba32(0,0,0,0);
			
			bool foundColors = false;
			for (int y = 0; y < patternY && !foundColors; y++) {
				for (int x = 0; x < patternX && !foundColors; x++) {
					if (suitColor.A != 0 && visorColor.A != 0) {
						// Break out of loops when already found colors
						foundColors = true;
						break;
					}
					
					switch (pat[x,y]) {
						case 0: // Don't save but also don't throw exception
							break;
						case 1: 
							if(suitColor.A == 0)
								suitColor = image[width + y, height + x];
							break;
						case 2:
							if(visorColor.A == 0)
								visorColor = image[width + y, height + x];
							break;
						case 3: // Don't save but also don't throw exception
							continue;
						default:
							throw new DataException("Unknown value in pattern found!");
					}
				}
			}

			bool isMatchingCurrent = true;
			// Check for pattern with correct colors
			for (int x = 0; x < patternX && isMatchingCurrent; x++) {
				for (int y = 0; y < patternY && isMatchingCurrent; y++) {
					Rgba32 currentColor = image[width + y, height + x];

					switch (pat[x, y]) {
						case 0:
							if (currentColor == suitColor || currentColor == visorColor)
								isMatchingCurrent = false;
							break;
						case 1: 
							if (currentColor != suitColor)
								isMatchingCurrent = false;
							break;
						case 2:
							if (currentColor != visorColor)
								isMatchingCurrent = false;
							break;
						case 3:
							// Don't care
							continue;
					}
				}
			}

			if (isMatchingCurrent)
				return true; // Current pattern matches --> No further search needed
		}

		return false;
	}
}