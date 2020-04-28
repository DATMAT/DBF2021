using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassBog : ClassUdlaan

    {
		private int _id;
		private string _isbnNr;
		private string _titel;
		private string _forfatter;
		private string _forlag;
		private string _genre;
		private string _type;
		private decimal _pris;
		public ClassBog()
        {
			id = 0;
			isbnNr = "";
			titel = "";
			forfatter = "";
			forlag = "";
			genre = "";
			type = "";
			pris = 0;
			
	}

		

		public int id
		{
			get { return _id; }
			set
			{
				if (_id != value)
				{
					_id = value;
				}
				Notify("id");
			}
		}
		

		public string isbnNr
		{
			get { return _isbnNr; }
			set
			{
				if (_isbnNr != value)
				{
					_isbnNr = value;
				}
				Notify("isbnNr");
			}
		}
		

		public string titel
		{
			get { return _titel; }
			set
			{
				if (_titel != value)
				{
					_titel = value;
				}
				Notify("_titel");
			}
		}
		

		public string forfatter
		{
			get { return _forfatter; }
			set
			{
				if (_forfatter != value)
				{
					_forfatter = value;
				}
				Notify("forfatter");
			}
		}
	

		public string forlag
		{
			get { return _forlag; }
			set
			{
				if (_forlag != value)
				{
					_forlag = value;
				}
				Notify("forlag");
			}
		}
		

		public string genre
		{
			get { return _genre; }
			set
			{
				if (_genre != value)
				{
					_genre = value;
				}
				Notify("genre");
			}
		}
		

		public string type
		{
			get { return _type; }
			set
			{
				if (_type != value)
				{
					_type = value;
				}
				Notify("type");
			}
		}
		

		public decimal pris
		{
			get { return _pris; }
			set
			{
				if (_pris != value)
				{
					_pris = value;
				}
				Notify("pris");
			}
		}



	}
}
