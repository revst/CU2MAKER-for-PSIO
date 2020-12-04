using System;
using System.IO;


class CU2MAKER
	{
		static void Main()
		{
		DirectoryInfo indir = new DirectoryInfo (".");
		FileInfo [] track = indir.GetFiles("*.bin");	

		FileStream fs = new FileStream((indir.Name+".CU2"), FileMode.Create);
		StreamWriter sw = new StreamWriter(fs);
		Console.WriteLine();
		
		//ntracks
		int trknum = track.GetUpperBound(0)+1;
		Console.WriteLine(" ntracks --> "+ trknum);
		sw.WriteLine("ntracks " + trknum);
		//ntracks
		
		
		//Info CDsizeBytes
		long LengthBytes = 0;
			foreach (FileInfo trk in track)
			{
			LengthBytes+=trk.Length;
			}
		Console.WriteLine(" CD size --> {0} bytes", LengthBytes);
		//Info CDsizeBytes


		//size
		float msec = LengthBytes/176400f;
		uint sec = (UInt32)(msec);
		uint min = sec/60;
		
		sw.WriteLine("size      {0:d2}:{1:d2}:{2:d2}",min,(sec-min*60),((UInt32)((msec-sec)*100)));
		
		Console.WriteLine(" CD size --> {0} sec", msec);
		//size
		
		
		//data1
		sw.WriteLine("data1     00:02:00");
		//data1
		
		//data1 offset(2sec) + Track01
		Console.WriteLine();
		Console.WriteLine(" Track 01 + 02 sec");
		
		LengthBytes = 352800+track [0].Length; //data1 offset(2sec) + Track01
		//data1 offset(2sec) + Track01



			//track02 - trackXX
			for (int x=1; x<trknum; x++)
			{
			Console.WriteLine();
			Console.WriteLine(" Processing BIN Track {0:d2}",(x+1));
			
			//detect audio silence for PREGAP
			byte [] bfile = File.ReadAllBytes(track [x].Name);
			uint SilenceBytes=0;
			while (bfile[SilenceBytes]==0) SilenceBytes++;
		
			float SilenceMsec = SilenceBytes/176400f;
			//detect audio silence for PREGAP
			
			
			Console.WriteLine(" PREGAP Dtected --> {0} sec", SilenceMsec);
			Console.WriteLine(" PREGAP Written --> {0} sec", ((UInt32)(SilenceMsec)));
			
			
			msec=LengthBytes/176400f +(UInt32)(SilenceMsec);
			Console.WriteLine(" Start of WAV data --> {0} sec", msec);
			sec = (UInt32)(msec);
			min = sec/60;
			sw.WriteLine("track{0:d2}   {1:d2}:{2:d2}:{3:d2}",(x+1),min,(sec-min*60),((UInt32)((msec-sec)*100)));
	
			LengthBytes += track [x].Length;
			Console.WriteLine();
			}
			//track02 - trackXX
			
			
			
		//trk end	
		Console.WriteLine();
		msec = LengthBytes/176400f;
		sec = (UInt32)(msec);
		min = sec/60;
		sw.WriteLine();
		sw.Write("trk end   {0:d2}:{1:d2}:{2:d2}",min,(sec-min*60),((UInt32)((msec-sec)*100)));
		Console.WriteLine(" trk end --> {0} sec", msec);
		//trk end
		
		Console.WriteLine();
		Console.WriteLine("Done!");
		
		sw.Close();
		fs.Close();
		Console.ReadLine();
		}
	}
