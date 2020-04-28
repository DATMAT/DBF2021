using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassPerson : ClassNotify
    { 
		private int _id;
		private string _navn;
		private string _adresse;
		private string _telefon;
		private string _mail;
		private int _rolle;

		public ClassPerson()
		{
			id = 0;
			navn = "";
			adresse = "";
			telefon = "";
			mail = "";
			rolle = 1;
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
		public string navn
		{
			get { return _navn; }
			set
			{
				if (_navn != value)
				{
					_navn = value;
				}
				Notify("navn");
			}
		}
		public string adresse
		{
			get { return _adresse; }
			set
			{
				if (_adresse != value)
				{
					_adresse = value;
				}
				Notify("adresse");
			}
		}
		public string telefon
		{
			get { return _telefon; }
			set
			{
				if (_telefon != value)
				{
					_telefon = value;
				}
				Notify("telefon");
			}
		}
		public string mail
		{
			get { return _mail; }
			set
			{
				if (_mail != value)
				{
					_mail = value;
				}
				Notify("mail");
			}
		}
		public int rolle
		{
			get { return _rolle; }
			set
			{
				if (_rolle != value)
				{
					_rolle = value;
				}
				Notify("rolle");
			}
		}
	}
}
