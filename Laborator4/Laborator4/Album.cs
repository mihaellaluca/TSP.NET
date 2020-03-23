using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4
{
	public class Album
	{
		public string AlbumId { get; set; }
		public string AlbumName { get; set; }
		public ICollection<ArtistAlbum> ArtistAlbum { get; set; }
	}
}
