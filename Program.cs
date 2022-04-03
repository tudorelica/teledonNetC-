using System;
using teledonNet.Interfaces;
using teledonNet.Model;
using teledonNet.Repo;

namespace teledonNet {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("P 1.0 completed!");

            String url = "Data Source=D:/Informatica_Romana/An_3/Sem-2/MPP/databases/Teledon.sqlite";

            System.Console.WriteLine("");
            System.Console.WriteLine("Cazuri Caritabile:");
            try {
                CazCaritabilRepository cazuriRepo = new CazCaritabilDbRepo(url);
                List<CazCaritabil> listaCazuri = (List<CazCaritabil>)cazuriRepo.FindAll();

                foreach (CazCaritabil caz in listaCazuri) {
                    System.Console.WriteLine("\t" + caz.titlu);
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Eroare la CazCaritabil Db Repo: " + ex);
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Voluntari:");
            try {
                var voluntariRepo = new teledonNet.VolDbRepo.VoluntarDbRepo(url);
                List<Voluntar> listaVoluntari = (List<Voluntar>)voluntariRepo.FindAll();

                foreach (Voluntar voluntar in listaVoluntari) {
                    System.Console.WriteLine("\t" + voluntar.nume);
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Eroare la Voluntar Db Repo: " + ex);
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Donatii:");
            try {
                var donatiiRepo = new teledonNet.VolDbRepo.DonatieDbRepo(url);
                List<Donatie> listaDonatii = (List<Donatie>)donatiiRepo.FindAll();

                foreach (Donatie donatie in listaDonatii) {
                    System.Console.WriteLine("\tid_caz=" + donatie.ID_caz_caritabil + "/tnume_donator=" + donatie.nume_donator);
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Eroare la Donatie Db Repo: " + ex);
            }




        }
    }
}
