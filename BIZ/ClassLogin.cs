using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;
namespace BIZ
{
    public class ClassLogin : ClassNotify
    {
		
		private string _id;
		private string _user;

		public ClassLogin()
		{
			id = "0";
			user = "";
		}

		public string user
		{
			get { return _user; }
			set
			{
				if (_user != value)
				{
					_user = value;
				}
				Notify("user");
	
			}
		}

		public string id
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
		public ClassPerson GetUserData()
		{
			ClassDbfDB db = new ClassDbfDB();
			ClassPerson res = db.GetUser(user, id);
			return res;
		}
	}
}
