namespace System.Data.SqlClient;


public class SampleDatabase
{
  
    //Connection to Database
    public void SampleStore()
    {
        // 1.Create Connection
        //string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=C#_Database;Integrated Security=True;Pooling=False";
        string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);

        // 2.Open Connection to DB
        connection.Open();

        string queryString = "select * from production.products ";

        //3. Reader
        SqlCommand command = new SqlCommand(queryString, connection);
        SqlDataReader reader = command.ExecuteReader();


        while (reader.Read())
        {
            Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());

        }
        reader.Close();
        connection.Close();
    }

    //Connection to  Database Using (using keyword)
    public void SampleStore1()
    {
        string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string queryString = "select * from production.products ";

            //3. Reader
            SqlCommand command = new SqlCommand(queryString, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());

                }
            }
        }
    }

    //Update Query of Database

    public void SampleStore2()
    {
        string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "update production.products set list_price=list_price *10 ";

            //3. Reader
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffected=command.ExecuteNonQuery();

            Console.WriteLine(rowAffected); 
          
        }
    }


    public void SampleStore3()
    {
        string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "update production.products set list_price=list_price *10 ";

            //string query = "insert into production.brands (brand_name) values(@brand_name)";

            //3. Reader
            SqlCommand command = new SqlCommand(query, connection);

            int rowAffected = command.ExecuteNonQuery();

            Console.WriteLine(rowAffected);

        }
    }

    //Stored Procedures of Database

    public void SampleStore5()
    {
        string connectionString = @"Data Source=WAIANGDESK23\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            //3. Reader
            SqlCommand command = new SqlCommand("testing", connection);
            command.CommandType =System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@brand_name", "Electra"));

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());

                }
            }
        }
    }
}
