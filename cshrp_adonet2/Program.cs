using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cshrp_adonet2
{
    class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            string connectionString = "Data Source=ELEV\\SQLEXPRESS;Initial Catalog=NORTHWIND;Integrated Security=SSPI";

            SqlConnection con = new SqlConnection(connectionString);
            string sqlRead;

            try {
                //p.connectDB();

                con.Open();

                Console.WriteLine("Hej var kund , Du kan valja en av de val som finns");
                Console.WriteLine("1.Visa alla i en Lista");
                Console.WriteLine("2.lagg till en ny produkt");
                Console.WriteLine("3.uppdatera (Ange ID)");
                Console.WriteLine("4.Ta bort (Ange ID)");
                Console.WriteLine("5.Avsluta");

                int choice = int.Parse(Console.ReadLine().ToString());
                switch (choice)
                {
                    case 1:
                        //1.Visa alla i en Lista
                        sqlRead = "SELECT [ProdName], [QuantityPerUnit], [UnitPrice] FROM [dbo].[Products]";
                        p.visaAlla(sqlRead, con);
                        break;
                    case 2:
                        //2.lagg till en ny produkt
                        //sqlRead, ProdName, CategoryID, SupplierID, Discontinued
                        sqlRead = "";
                        p.laggTillNyaProduct(con, sqlRead, "FINTproduct", 11, 11, 1);
                        break;
                    case 3:
                        //3.uppdatera (Ange ID)
                        sqlRead = "";
                        p.UppdateraProduct(sqlRead, 1, con);
                        break;
                    case 4:
                        //4.Ta bort (Ange ID)
                        
                        p.TaBortProduct(con, 1);
                        break;
                    case 5:
                        //5.Avsluta
                        break;
                    default:
                        break;
                }

                //dataReader.Close();
                //command_read.Dispose();

                Console.ReadLine();
                con.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();            
        }
        
        private void TaBortProduct(SqlConnection con, int PoductID)
        {
            string SqlDelete = "DELETE FROM Products WHERE ID = "+ PoductID;
            SqlCommand command_delete = new SqlCommand(SqlDelete, con);
            try
            {
                int reultat_delete = command_delete.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine("Can't delte!");
            }finally{
                con.Close();
            }

            command_delete.Dispose();
        }
        
        private void visaAlla(String sqlRead, SqlConnection con)
        {   
            SqlCommand command_read = new SqlCommand(sqlRead, con);
            SqlDataReader dataReader = command_read.ExecuteReader();
            while (dataReader.Read())
            {
                //Console.WriteLine(dataReader.GetValue(0));        //dataReader[""].ToString()  + " " +
                Console.WriteLine(
                    dataReader["ProdName"] + "\t " +
                    dataReader["QuantityPerUnit"].ToString() + "\t " +
                    dataReader["UnitPrice"].ToString()
                );   //  + " "
            }

            dataReader.Close();
            command_read.Dispose();
        }

        private void laggTillNyaProduct(SqlConnection con, string sqlRead, string v1, int v2, int v3, int v4)
        {

        }

        private void UppdateraProduct(string sqlRead, int v, SqlConnection con)
        {

        }
    }
}
