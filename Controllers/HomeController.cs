using _26FebbraioEs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26FebbraioEs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Dipendenti";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   SqlDataReader rdr = cmd.ExecuteReader();
                    List<Dipendente> dipendenti = new List<Dipendente>();
                    while (rdr.Read())
                    {
                        Dipendente dipendente = new Dipendente();
                      
                        dipendente.Nome = rdr["Nome"].ToString();
                        dipendente.Cognome = rdr["Cognome"].ToString();
                        dipendente.Indirizzo = rdr["Indirizzo"].ToString();
                        dipendente.CodiceFiscale = rdr["CodiceFiscale"].ToString();
                        dipendente.Coniugato = Convert.ToBoolean(rdr["Coniugato"]);
                        dipendente.FigliACarico = Convert.ToInt32(rdr["FigliACarico"]);
                        dipendente.Mansione = rdr["Mansione"].ToString();
                        dipendenti.Add(dipendente);
                    }
                    return View(dipendenti);
                }
            }
            
        }

        public ActionResult Dipendente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciDipendente(Models.Dipendente dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                        INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, FigliACarico, Mansione) 
                        VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @FigliACarico, @Mansione)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
                    cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                    cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                    cmd.Parameters.AddWithValue("@CodiceFiscale", dipendente.CodiceFiscale);
                    cmd.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
                    cmd.Parameters.AddWithValue("@FigliACarico", dipendente.FigliACarico);
                    cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Response.Write("Errore");
                    }
                }
            }

            return RedirectToAction("Index");
        }



        public ActionResult Pagamento()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InserisciPagamento(Models.Pagamento pagamento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                        INSERT INTO Pagamenti (IdDipendente, PeriodoPagamento, Ammontare, TipoPagamento) 
                        VALUES (@IdDipendente, @PeriodoPagamento, @Ammontare, @TipoPagamento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdDipendente", pagamento.IdDipendente);
                    cmd.Parameters.AddWithValue("@PeriodoPagamento", pagamento.PeriodoPagamento);
                    cmd.Parameters.AddWithValue("@Ammontare", pagamento.Ammontare);
                    cmd.Parameters.AddWithValue("@TipoPagamento", pagamento.TipoPagamento);
                   

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Response.Write("Errore");
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}