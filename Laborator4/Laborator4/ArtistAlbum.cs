using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4
{
	public class ArtistAlbum
	{
		public string ArtistId { get; set; }
		public Artist Artist { get; set; }
		public string AlbumId { get; set; }
		public Album Album { get; set; }
	}
}
