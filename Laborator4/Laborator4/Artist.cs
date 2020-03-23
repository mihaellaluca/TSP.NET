using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4
{
	public class Artist
	{
		public string ArtistId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<ArtistAlbum> ArtistAlbum { get; set; }
	}
}
