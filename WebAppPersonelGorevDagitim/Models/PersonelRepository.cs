using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Linq.Expressions;
using System.Data;
using Dapper;

namespace WebAppPersonelGorevDagitim.Models
{
    public class PersonelRepository
    {
        public IEnumerable<Personel> GetPersonels(int? PersonelId, Func<Personel,bool> FilterExpression = null)
        {
            string Sql = "select * from Personel where 1=1";
            if (PersonelId != null)  // details ve edit icin hizli metod
            {
                Sql += " and PersonelId = " + PersonelId.ToString();
            }

            IEnumerable<Personel> personels = new List<Personel>();

            using(var connection = new SqlConnection(Startup.ConnectionString))
            {
                personels = connection.Query<Personel>(Sql).ToList();

                if (FilterExpression != null)  // extra filtreler icin
                {
                    personels = personels.Where(FilterExpression);
                }
            }

            return personels;
        }

        public DBOperationResult CreatePersonel(Personel personel)
        {
            string Sql = @"INSERT INTO Personel (PersonelAdi, PersonelSoyadi)
VALUES  (@PersonelAdi, -- varchar(50)
		 @PersonelSoyadi -- varchar(50)
		 )";

            DBOperationResult result = new DBOperationResult();

            using (var connection = new SqlConnection(Startup.ConnectionString))
            {
                try
                {
                    result.AffectedRows = connection.Execute(Sql, personel);
                }
                catch (Exception E)
                {
                    result.Ok = false;
                    result.exception = E;
                    //throw;
                }                
            }

            return result;
        }

        public DBOperationResult UpdatePersonel(Personel personel)
        {
            string Sql = @"update Personel set
PersonelAdi = @PersonelAdi,
PersonelSoyAdi = @PersonelSoyAdi
where PersonelId = @PersonelId";

            DBOperationResult result = new DBOperationResult();

            using (var connection = new SqlConnection(Startup.ConnectionString))
            {
                try
                {
                    result.AffectedRows = connection.Execute(Sql, personel);
                }
                catch (Exception E)
                {
                    result.Ok = false;
                    result.exception = E;
                    //throw;
                }
            }

            return result;
        }

        public DBOperationResult DeletePersonel(Personel personel)  // id parametresi alan, model almayan hale de getirilebilir, ancak loglama acisindan bu hali daha iyi
        {
            string Sql = @"delete from Personel where PersonelId = @PersonelId";

            DBOperationResult result = new DBOperationResult();

            using (var connection = new SqlConnection(Startup.ConnectionString))
            {
                try
                {
                    result.AffectedRows = connection.Execute(Sql, personel);
                }
                catch (Exception E)
                {
                    result.Ok = false;
                    result.exception = E;
                    //throw;
                }
            }

            return result;
        }

        
    }

}
