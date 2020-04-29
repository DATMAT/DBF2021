using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
	public class ClassBIZ: ClassNotify
	{
		private ObservableCollection<ClassBog> _boeger;
		private ObservableCollection<ClassBog> _laanteBoeger;
		private ClassBog _bog;
		private ClassPerson _person;

		public ClassBIZ()
		{
		}
		
		public ClassPerson person
		{
			get { return _person; }
			set
			{
				if (_person != value)
				{
					_person = value;
				}
				Notify("person");
			}
		}
		public ClassBog bog
		{
			get { return _bog; }
			set
			{
				if (_bog != value)
				{
					_bog = value;
				}
				Notify("bog");
			}
		}
		public ObservableCollection<ClassBog> laanteBoeger
		{
			get { return _laanteBoeger; }
			set
			{
				if (_laanteBoeger != value)
				{
					_laanteBoeger = value;
				}
				Notify("laanteBoeger");
			}
		}
		public ObservableCollection<ClassBog> boeger
		{
			get { return _boeger; }
			set
			{
				if (_boeger != value)
				{
					_boeger = value;
				}
				Notify("boeger");
			}
		}


		public ObservableCollection<ClassBog> GetAllLentBoks(int inID)
		{
			laanteBoeger = GetAllBooksLentToUser(inID);

			return;
		}

		public ObservableCollection<ClassBog> GetAllBooksWhereTheTitleContainsTheseWords(string SøgTekst)
		{
			boeger = GetAllBooksLike(søgTekst);

			return;
		}

		public void LendThisBookToTheUser(bog.id, person.id)
		{

		}

		public void SubmitThisBookToTheLibrary(bog.id, person.id)
		{
			
		}

		public bool CheckForDoubleLending(bog)
		{


			bool Res = true;
			return Res;
		}

	}
}
