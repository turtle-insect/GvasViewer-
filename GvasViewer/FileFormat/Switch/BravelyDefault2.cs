﻿using GvasViewer.Gvas;
using GvasViewer.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GvasViewer.FileFormat.Switch
{
	internal class BravelyDefault2 : IFileFormat
	{
		public (GvasStructProperty property, uint length) Create(uint address, string name)
		{
			switch(name)
			{
				case "Rotator":
					return (new GvasStructProperty(), 12);
			}

			return (new GvasStructProperty(), 0);
		}

		public byte[] Load(string filename)
		{
			Byte[] buffer = System.IO.File.ReadAllBytes(filename);
			buffer = buffer.Skip(12).ToArray();
			buffer = Zlib.Decompress(buffer);
			return buffer;
		}

		public void Save(string filename, byte[] buffer)
		{
			Byte[] header = Encoding.UTF8.GetBytes("SAVE");
			header = header.Concat(BitConverter.GetBytes(1)).ToArray();
			header = header.Concat(BitConverter.GetBytes(buffer.Length)).ToArray();

			buffer = Zlib.Compression(buffer);

			buffer = header.Concat(buffer).ToArray();

			System.IO.File.WriteAllBytes(filename, buffer);
		}
	}
}
