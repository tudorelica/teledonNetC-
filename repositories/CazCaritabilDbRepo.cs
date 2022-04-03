using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teledonNet.Interfaces;
using teledonNet.Model;

namespace teledonNet.Repo
{

    
    class CazCaritabilDbRepo : CazCaritabilRepository
    {
        private string url;
        // private static readonly ILog log = LogManager.GetLogger("CazCaritabilRepository");

        public CazCaritabilDbRepo(string url)
        {
            this.url = url;
        }

        public CazCaritabil FindOne(int id)
        {
            string sqlCom = "select * from CazuriCaritabile where id=@id";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var idd = cmd.CreateParameter();
                    idd.ParameterName = "@id";
                    idd.Value = id;
                    cmd.Parameters.Add(idd);
                    using (var data = cmd.ExecuteReader())
                    {
                        if (data.Read())
                        {
                            String titlu = data.GetString(1);
                            String descriere = data.GetString(2);
                            CazCaritabil caz = new CazCaritabil( titlu, descriere);

                            return caz;
                        }
                    }
                }
            }
            return null;
        }
        public IEnumerable<CazCaritabil> FindAll()
        {
            // log.InfoFormat("Entering findAll");
            IList<CazCaritabil> list = new List<CazCaritabil>();
            string sqlCom = "select * from CazuriCaritabile";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlCom, conn);
                using (var data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        int id = data.GetInt32(0);
                        String titlu = data.GetString(1);
                        String descriere = data.GetString(2);
                        CazCaritabil p = new CazCaritabil(id, titlu, descriere);
                        // log.InfoFormat("Found {0}", p);
                        list.Add(p);
                    }
                }
            }
            // log.InfoFormat("Exiting findAll");
            return list;
        }
        public CazCaritabil Add(CazCaritabil entity)
        {
            CazCaritabil caz = entity;
            string sqlCom = "insert into CazuriCaritabile (id,titlu, descriere) values (@id, @titlu, @descriere)";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var titlu = cmd.CreateParameter();

                    titlu.ParameterName = "@titlu";
                    titlu.Value = entity.titlu;
                    cmd.Parameters.Add(titlu);
                    if (cmd.ExecuteNonQuery() > 0)
                        caz = null;
                }
            }
            return caz;
        }
        public CazCaritabil Delete(int id)
        {
            CazCaritabil caz = FindOne(id);
            string sqlCom = "delete from CazuriCaritabile where id=@id";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var idd = cmd.CreateParameter();
                    idd.ParameterName = "@id";
                    idd.Value = id;
                    cmd.Parameters.Add(idd);
                    cmd.ExecuteNonQuery();
                }
            }
            return caz;
        }
        public CazCaritabil Update(CazCaritabil entity)
        {
            CazCaritabil caz = FindOne(entity.Id);
            string sqlCom = "update CazuriCaritabile set titlu=@titlu,descriere=@descriere where id=@id";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var titlu = cmd.CreateParameter();

                    titlu.ParameterName = "@titlu";
                    titlu.Value = entity.titlu;
                    cmd.Parameters.Add(titlu);

                    var descriere = cmd.CreateParameter();

                    descriere.ParameterName = "@descriere";
                    descriere.Value = entity.descriere;
                    cmd.Parameters.Add(descriere);

                    cmd.ExecuteNonQuery();
                }
            }
            return caz;
        }
    }




    
}
