using NAudio.Wave;
using System.Diagnostics;
using System;
using System.IO;

namespace ConvertMp3ToWav2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				DisplayHelp();
				return;
			}

			Stopwatch watch = new Stopwatch();
			watch.Start();

			if (!File.Exists(args[0]))
			{
				Console.WriteLine($"File '{args[0]}' doesn't exist!");
				return;
			}

			// http://markheath.net/post/converting-mp3-to-wav-with-naudio
			using (Mp3FileReader reader = new Mp3FileReader(args[0]))
			using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
			{
				WaveFileWriter.CreateWaveFile(args[1], pcmStream);
			}

			watch.Stop();
			Console.WriteLine($"It took {watch.Elapsed}");
		}

		private static void DisplayHelp()
		{
			Console.WriteLine("m2w.exe <input> <output>");
		}
	}
}
