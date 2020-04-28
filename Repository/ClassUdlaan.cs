using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassUdlaan : Notify
    {
		private DateTime _afleveringsDato;
		public ClassUdlaan()
		{
		}


		public DateTime afleveringsDato
		{
			get { return _afleveringsDato; }
			set
			{
				if (_afleveringsDato != value)
				{
					_afleveringsDato = value;
				}
				Notify("afleveringsDato");
			}
		}

		public void BeregnAfleveringsDato(DateTime lentdate, string userStatus)
		{
			if (userStatus == "normallåner")
			{
				DateTime afleveringsDato = lentdate.AddDays(30);
			}
			else
			{
				DateTime afleveringsDato = lentdate.AddDays(60);
			}
		}

	}
}
