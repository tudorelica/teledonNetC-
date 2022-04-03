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
    class DonatieDbRepo : DonatieRepository
    {
        private string url;
        // private static readonly ILog log = LogManager.GetLogger("CazCaritabilRepository");

        public DonatieDbRepo()
        {
        }
        public DonatieDbRepo(string url)
        {
            this.url = url;
        }

        public Donatie FindOne(int id)
        {
            string sqlCom = "select * from Donatii where id=@id";
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
                            int ID_caz_caritabil = data.GetInt32(1);
                            String nume_donator = data.GetString(2);
                            String nr_telefon = data.GetString(3);
                            Double suma = data.GetDouble(4);
        
                            Donatie donatie = new Donatie( ID_caz_caritabil, nume_donator, nr_telefon, suma);

                            return donatie;
                        }
                    }
                }
            }
            return null;
        }
        public IEnumerable<Donatie> FindAll()
        {
            // log.InfoFormat("Entering findAll");
            IList<Donatie> list = new List<Donatie>();
            string sqlCom = "select * from Donatii";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                var cmd = new SQLiteCommand(sqlCom, conn);
                using (var data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        int id = data.GetInt32(0);
                        int ID_caz_caritabil = data.GetInt32(1);
                        String nume_donator = data.GetString(2);
                        String nr_telefon = data.GetString(3);
                        Double suma = data.GetDouble(4);
        
                        Donatie donatie = new Donatie( ID_caz_caritabil, nume_donator, nr_telefon, suma);
                        donatie.Id = id;

                        list.Add(donatie);
                    }
                }
            }
            // log.InfoFormat("Exiting findAll");
            return list;
        }
        
        public Donatie Add(Donatie entity)
        {
            Donatie donatie = entity;
            string sqlCom = "insert into Donatii (id, id_caz_caritabil, nume_donator, numar_telefon, suma) values (@id, @id_caz_caritabil, @nume_donator, @numar_telefon, @suma)";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var id_caz_caritabil = cmd.CreateParameter();

                    id_caz_caritabil.ParameterName = "@id_caz_caritabil";
                    id_caz_caritabil.Value = entity.ID_caz_caritabil;
                    cmd.Parameters.Add(id_caz_caritabil);

                    var nume_donator = cmd.CreateParameter();

                    nume_donator.ParameterName = "@nume_donator";
                    nume_donator.Value = entity.nume_donator;
                    cmd.Parameters.Add(nume_donator);

                    var numar_telefon = cmd.CreateParameter();

                    numar_telefon.ParameterName = "@numar_telefon";
                    numar_telefon.Value = entity.numar_telefon;
                    cmd.Parameters.Add(numar_telefon);

                    var suma = cmd.CreateParameter();

                    suma.ParameterName = "@suma";
                    suma.Value = entity.suma;
                    cmd.Parameters.Add(suma);

                    if (cmd.ExecuteNonQuery() > 0)
                        donatie = null;
                }
            }
            return donatie;
        }
        public Donatie Delete(int id)
        {
            Donatie donatie = FindOne(id);
            string sqlCom = "delete from Donatii where id=@id";
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
            return donatie;
        }
        public Donatie Update(Donatie entity)
        {
            Donatie donatie = FindOne(entity.Id);
            string sqlCom = "update Donatii set id_caz_caritabil=@id_caz_caritabil,nume_donator=@nume_donator,numar_telefon=@numar_telefon,suma=@suma where id=@id";
            using (var conn = new SQLiteConnection(url))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sqlCom, conn))
                {
                    var id = cmd.CreateParameter();

                    id.ParameterName = "@id";
                    id.Value = entity.Id;
                    cmd.Parameters.Add(id);

                    var id_caz_caritabil = cmd.CreateParameter();

                    id_caz_caritabil.ParameterName = "@id_caz_caritabil";
                    id_caz_caritabil.Value = entity.ID_caz_caritabil;
                    cmd.Parameters.Add(id_caz_caritabil);

                    var nume_donator = cmd.CreateParameter();

                    nume_donator.ParameterName = "@nume_donator";
                    nume_donator.Value = entity.nume_donator;
                    cmd.Parameters.Add(nume_donator);

                    var numar_telefon = cmd.CreateParameter();

                    numar_telefon.ParameterName = "@numar_telefon";
                    numar_telefon.Value = entity.numar_telefon;
                    cmd.Parameters.Add(numar_telefon);

                    var suma = cmd.CreateParameter();

                    suma.ParameterName = "@suma";
                    suma.Value = entity.suma;
                    cmd.Parameters.Add(suma);

                    cmd.ExecuteNonQuery();
                }
            }
            return donatie;
        }
    }
}
