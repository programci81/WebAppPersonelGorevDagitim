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
    public class ProsesDagitimRepository
    {
        public IEnumerable<ProsesDagitimView> GetProsesDagitims(DateTime Tarih, Func<ProsesDagitimView, bool> FilterExpression = null)
        {
            string Sql = @"select PD.PDId, PD.Tarih, Personel.PersonelAdi, Personel.PersonelSoyadi, Proses.ProsesAdi, Proses.Zorluk FROM ProsesDagitim PD
LEFT JOIN Personel ON PD.PersonelId = Personel.PersonelId
LEFT JOIN Proses ON PD.ProsesId = Proses.ProsesId
where Tarih = " + IBLibStatic.ToSqlString(Tarih.ToString("yyyy-MM-dd")) +
"order by Personel.PersonelAdi, Personel.PersonelSoyadi";

            IEnumerable<ProsesDagitimView> prosesDagitims = new List<ProsesDagitimView>();

            using(var connection = new SqlConnection(Startup.ConnectionString))
            {
                prosesDagitims = connection.Query<ProsesDagitimView>(Sql).ToList();

                if (FilterExpression != null)  // extra filtreler icin
                {
                    prosesDagitims = prosesDagitims.Where(FilterExpression);
                }
            }

            return prosesDagitims;
        }

        // TODO: modift for create, call sp
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

        public DBOperationResult DagitimListesiOlustur(DateTime Tarih)
        {
            string Sql = @"exec ProsesDagit @Tarih = " + IBLibStatic.ToSqlDate(Tarih);

            DBOperationResult result = new DBOperationResult();

            using (var connection = new SqlConnection(Startup.ConnectionString))
            {
                try
                {
                    result.AffectedRows = connection.Execute(Sql);
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
