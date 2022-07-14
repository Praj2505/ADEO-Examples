using System;
using System.Data;
using System.Data.SqlClient;

//Data Source=Prajwal;Initial Catalog=mydb;Integrated Security=True
//ADOExamples

//Installing:

//Microsoft.NETCore.Platforms.3.1.0
//Microsoft.Win32.Registry.4.7.0
//runtime.native.System.Data.SqlClient.sni.4.7.0
//runtime.win - arm64.runtime.native.System.Data.SqlClient.sni.4.4.0
//runtime.win - x64.runtime.native.System.Data.SqlClient.sni.4.4.0
//runtime.win - x86.runtime.native.System.Data.SqlClient.sni.4.4.0
//System.Data.SqlClient.4.8.3
//System.Security.AccessControl.4.7.0
//System.Security.Principal.Windows.4.7.0



namespace ADOExamples
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand com;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            try
            {             //con = new SqlConnection("Data Source=Prajwal;initial catelog=mydb;User=sa;Password=sa");// if database has id pass
                con = new SqlConnection("Data Source=Prajwal;database=mydb;integrated security=True");// database or initia catalog, with or of them will work
                con.Open();

                com = new SqlCommand();
                com.Connection = con;
                //com.CommandText="select city,country,capital from city";
                //com.CommandText = "create table students (id integer Identity(1,1),  firstname varchar(20), lastname varchar(20))";
                //dr = com.ExecuteReader();
                //while(dr.Read())
                //{
                //    Console.WriteLine($"{dr[0]} | {dr[1]} | {dr[2]}");
                //}
                Console.WriteLine("enter first name: ");
                string firstname = Console.ReadLine();
                Console.WriteLine("enter last name: ");
                string lastname = Console.ReadLine();


                com.CommandText = "insert into person (firstname,lastname)values(@fname,@lname)";


                SqlParameter p1 = new SqlParameter("@fname", SqlDbType.VarChar);
                p1.Value = firstname;
                com.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@lname", SqlDbType.VarChar);
                p2.Value = lastname;
                com.Parameters.Add(p2);

                com.ExecuteNonQuery();


            }

            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
