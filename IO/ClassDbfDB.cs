﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace IO
{
    public class ClassDbfDB : ClassDB
    {
        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            ObservableCollection<ClassBog> res = new ObservableCollection<ClassBog>();

            string sqlQuery = "SELECT Books.id, ISBNnr.isbnNr, Titel.titel, Forfatter.forfatter, Forlag.forlagsNavn, Genre.genreType, Type.TypeNavn, Books.pris " +
                "FROM Books INNER JOIN " +
                "ISBNnr ON Books.isbnID = ISBNnr.id INNER JOIN " +
                "Titel ON Books.titelID = Titel.id INNER JOIN " +
                "Forfatter ON Books.forfatterID = Forfatter.id INNER JOIN " +
                "Forlag ON Books.forlagID = Forlag.id INNER JOIN " +
                "Genre ON Books.genreID = Genre.id INNER JOIN " +
                "Type ON Books.typeID = Type.id " +
                $"WHERE  (dbo.Titel.titel LIKE '{search}%')";

            DataTable dt = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dt.Rows)
            {
                ClassBog cb = new ClassBog();

                cb.id = Convert.ToInt32(row["id"]);
                cb.isbnNr = row["isbnNr"].ToString();
                cb.title = row["titel"].ToString();
                cb.title = row["forfatter"].ToString();
                cb.title = row["forlagsNavn"].ToString();
                cb.title = row["genreType"].ToString();
                cb.title = row["TypeNavn"].ToString();
                cb.iD = Convert.ToDecimal(row["pris"]);

                res.Add(cb);
            }

            return res;
        }

        public ObservableCollection<ClassBog> GetAllBooksLentToUser(string id)
        {
            ObservableCollection<ClassBog> res = new ObservableCollection<ClassBog>();

            string sqlQuery = "SELECT Books.id, ISBNnr.isbnNr, Titel.titel, Forfatter.forfatter, Forlag.forlagsNavn, Genre.genreType, Type.TypeNavn, Books.pris " +
                "FROM Access INNER JOIN " +
                "Person ON Access.userID = Person.id INNER JOIN " +
                "Udlaan ON Person.id = Udlaan.personID INNER JOIN " +
                "Books ON Udlaan.bookID = Books.id INNER JOIN " +
                "ISBNnr ON Books.isbnID = ISBNnr.id INNER JOIN " +
                "Titel ON Books.titelID = Titel.id INNER JOIN " +
                "Forfatter ON Books.forfatterID = Forfatter.id INNER JOIN " +
                "Forlag ON Books.forlagID = Forlag.id INNER JOIN " +
                "Genre ON Books.genreID = Genre.id INNER JOIN " +
                "Type ON Books.typeID = Type.id " +
                $"WHERE(Access.cprNr = N'{id}') AND(Udlaan.udlansStatus = 1)";

            DataTable dt = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dt.Rows)
            {
                ClassBog cb = new ClassBog();

                cb.id = Convert.ToInt32(row["id"]);
                cb.isbnNr = row["isbnNr"].ToString();
                cb.title = row["titel"].ToString();
                cb.title = row["forfatter"].ToString();
                cb.title = row["forlagsNavn"].ToString();
                cb.title = row["genreType"].ToString();
                cb.title = row["TypeNavn"].ToString();
                cb.iD = Convert.ToDecimal(row["pris"]);

                res.Add(cb);
            }

            return res;
        }

        /// <summary>
        /// dette er bare et gæt.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status">true retuneret/false udlånt</param>
        public void UpdateTheLendingStatus(string bookID, string personId, bool status)
        {
            if (status)
            {
                string sqlQuery = $"UPDATE Udlaan " +
                                  $"SET udlansStatus = 2 " +
                                  $"WHERE(bookID = {bookID}) AND (personID = {personId})";
            }
            else
            {
                string sqlQuery = $"INSERT INTO Udlaan (bookID, personID, udlaansDato, udlansStatus) " +
                                  $"VALUES({bookID} ,{personId} , {DateTime.Today.ToString("YYYY-MM-DD")}, 1)";
            }

            FunctionExecuteNonQuery(sqlQuery);
        }

        public ClassPerson GetUser(string userID, string password)
        {
            ClassPerson res = new ClassPerson();

            string sqlQuery = $"SELECT Person.id, Person.naven, Person.adresse, PersonTelefon.telefonnummer, PersonMail.mailAdr, Person.rolle " +
                $"FROM Access INNER JOIN " +
                $"Person ON Access.userID = Person.id INNER JOIN " +
                $"PersonTelefon ON Person.id = PersonTelefon.personID INNER JOIN " +
                $"PersonMail ON Person.id = PersonMail.personID " +
                $"WHERE(Access.cprNr = N'{userID}') AND(Access.password = N'{password}')";

            DataTable dt = DbReturnDataTable(sqlQuery);
            
            foreach (DataRow row in dt.Rows)
            {
                res.id = Convert.ToInt32(row["id"]);
                res.navn = row["titel"].ToString();
                res.adresse = row["titel"].ToString();
                res.telefon = row["titel"].ToString();
                res.mail = row["titel"].ToString();
                res.rolle = Convert.ToInt32(row["id"]);
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns>true is not availble/false is availble</returns>
        public bool GetIsLendOut(string bookID)
        {
            int id = 0;
            string sqlQuery = $"SELECT id " +
                              $"FROM Udlaan " +
                              $"WHERE(bookID = {bookID}) AND (udlansStatus = 1)";

            DataTable dt = DbReturnDataTable(sqlQuery);
            foreach (DataRow row in dt.Rows)
            {
                id = Convert.ToInt32(row["id"]);
            }
            bool res = false;
            if (id != 0)
            {
                res = true;
            }
            return res;
        }
    }
}
