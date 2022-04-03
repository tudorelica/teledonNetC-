using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teledonNet.Interfaces;
using teledonNet.Model;

namespace teledonNet.VolDbRepo
{
    class VoluntarDbRepo : VoluntarRepository
    {
        private string url;
        // private static readonly ILog log = LogManager.GetLogger("CazCaritabilRepository");

        public VoluntarDbRepo()
        {
        }
        public VoluntarDbRepo(string url)
        {
            this.url = url;
        }

        public Voluntar FindOne(int id)
        {
            string sqlCom = "select * from Voluntari where id=@id";
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
                            String nume = data.GetString(1);
                            String username = data.GetString(2);
                            String password = data.GetString(3);
                            Voluntar voluntar = new Voluntar( nume, username, password);

                            return voluntar;
                        }
                    }
                }
            }
            return null;
        }
        public IEnumerable<Voluntar> FindAll()
        {
            // log.InfoFormat("Entering findAll");
            IList<Voluntar> list = new List<Voluntar>();
            string sqlCom = "select * from Voluntari";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlCom, conn);
                using (var data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        int id = data.GetInt32(0);
                        String nume = data.GetString(1);
                        String username = data.GetString(2);
                        String password = data.GetString(3);
                        Voluntar voluntar = new Voluntar( nume, username, password);

                        list.Add(voluntar);
                    }
                }
            }
            // log.InfoFormat("Exiting findAll");
            return list;
        }
        public Voluntar Add(Voluntar entity)
        {
            Voluntar voluntar = entity;
            string sqlCom = "insert into Voluntari (id, nume, username, password) values (@id, @nume, @username, @password)";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var nume = cmd.CreateParameter();

                    nume.ParameterName = "@nume";
                    nume.Value = entity.nume;
                    cmd.Parameters.Add(nume);

                    var username = cmd.CreateParameter();

                    username.ParameterName = "@username";
                    username.Value = entity.username;
                    cmd.Parameters.Add(username);

                    var password = cmd.CreateParameter();

                    password.ParameterName = "@password";
                    password.Value = entity.password;
                    cmd.Parameters.Add(password);

                    if (cmd.ExecuteNonQuery() > 0)
                        voluntar = null;
                }
            }
            return voluntar;
        }
        public Voluntar Delete(int id)
        {
            Voluntar voluntar = FindOne(id);
            string sqlCom = "delete from Voluntari where id=@id";
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
            return voluntar;
        }
        public Voluntar Update(Voluntar entity)
        {
            Voluntar voluntar = FindOne(entity.Id);
            string sqlCom = "update Voluntari set nume=@nume,username=@username,password=@password where id=@id";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var nume = cmd.CreateParameter();

                    nume.ParameterName = "@nume";
                    nume.Value = entity.nume;
                    cmd.Parameters.Add(nume);

                    var username = cmd.CreateParameter();

                    username.ParameterName = "@username";
                    username.Value = entity.username;
                    cmd.Parameters.Add(username);

                    var password = cmd.CreateParameter();

                    password.ParameterName = "@password";
                    password.Value = entity.password;
                    cmd.Parameters.Add(password);

                    cmd.ExecuteNonQuery();
                }
            }
            return voluntar;
        }
    }
}
