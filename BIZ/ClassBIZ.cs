using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;

namespace BIZ
{
	public class ClassBIZ : ClassNotify
	{
		private ObservableCollection<ClassBog> _boeger;
		private ObservableCollection<ClassBog> _laanteBoeger;
		private ClassBog _bog;
		private ClassPerson _person;
		private ClassDbfDB DbfDB;

		public ClassBIZ()
		{
			DbfDB = new ClassDbfDB();
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
			laanteBoeger = DbfDB.GetAllBooksLentToUser(inID);

			return laanteBoeger;
		}

		public ObservableCollection<ClassBog> GetAllBooksWhereTheTitleContainsTheseWords(string search)
		{
			boeger = DbfDB.GetAllBooksLike(search);

			return boeger;
		}

		public void LendThisBookToTheUser(int inBog, int inPerson)
		{

			DbfDB.UpdateTheLendingStatus(inBog, inPerson, false);
		}
				
		public void SubmitThisBookToTheLibrary(int inBog, int inPerson)
		{
			DbfDB.UpdateTheLendingStatus(inBog, inPerson, true);
		}

		public bool CheckForDoubleLending(int inBog)
		{			
			return DbfDB.GetIsLendOut(inBog);
		}

	}
}
