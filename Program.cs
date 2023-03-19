using System;
using MySqlConnector;

// dotnet new console -- create new C# project
// dotnet add package MySqlConnector -- add the MySQL Connector package
// dotnet build -- build the application

namespace Downloads
{
    class Program
    {
       static string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
       static void demo (){
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            string sql = "SELECT C.`Company`, E.`Last Name` " +
            "FROM Customers C, Employees E, Orders O " +
            "WHERE E.ID=O.`Employee ID` AND C.ID=O.`Customer ID` AND " +
            "O.`Shipping Fee` < @shipping_fee " +
            "ORDER BY O.`Shipping Fee`";  
            double maxfee = 20;
            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("Company" + ": " + "Last Name");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    Console.WriteLine(rdr["Company"] + ": " + rdr["Last Name"]);
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }


        static void EX05_01(){
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";

            //  cout << " what query do you want? ";

            string sql_EX05_01 = "SELECT `list price`, `standard cost` , (`list price`-`standard cost`) as profit " +
            "FROM Products";
          

            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql_EX05_01, conn);
               // cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("list price" + ": " + "standard cost" + ": " + "profit");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    Console.WriteLine(rdr["list price"] + ": " + rdr["standard cost"] + ": " + rdr["profit"]);
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void EX05_02(){
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";

            //  cout << " what query do you want? ";

            string sql_EX05_02 = "SELECT  min(`list price`-`standard cost`) as min, max(`list price`-`standard cost`) as max," + 
            " avg(`list price`-`standard cost`) as average " +
            "FROM Products";
          

            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql_EX05_02, conn);
               // cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("min" + ": " + "max" + ": " + "average");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    Console.WriteLine(rdr["min"] + ": " + rdr["max"] + ": " + rdr["average"]);
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }

        static void EX05_03(){
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";

            //  cout << " what query do you want? ";

            string sql_EX05_03 = "SELECT Category, count(*) as count FROM northwind.Products"+
            " GROUP BY Category ";
          

            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql_EX05_03, conn);
               // cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("Name a product kind: ");
                string product_Kind = Console.ReadLine();
                bool name_Exists = false;
                Console.WriteLine("category" + ": " + "count");
                while ((rdr.Read())) { // this reas through and the data like reading through a file
                if (rdr["category"].ToString() == product_Kind){ // this should get rid of SQL Injection attacks.
                    Console.WriteLine(rdr["category"] + ": " + rdr["count"]);
                    name_Exists = true;
                    break;
                }  
                }
                if(!name_Exists){
                    Console.WriteLine("Name does not exist");
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void EX05_04(){
            MySqlConnection conn;
            

      //  cout << " what query do you want? ";
            Console.WriteLine("Give a word: ");
            string answer = Console.ReadLine();
            if (answer.Contains(" ")){ // to Avoid SQL Injection attacks.
                Console.WriteLine("no spaces please");
            }else{
                string sql_EX05_04 = "SELECT  `product name`" + 
                " FROM northwind.Products" +
                " WHERE  `product name`  LIKE '%" + answer + "%'" ; 
                   try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql_EX05_04, conn);
               // cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                bool word_Exists = false;
                Console.WriteLine("product name");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    if (rdr["product name"].ToString().Contains(answer)){
                       Console.WriteLine(rdr["product name"]);
                       word_Exists = true;
                      // break; // can't use break because we need all possible answers and not just the first
                }
                }
                if (!word_Exists){
                    Console.WriteLine("Does not contain that word");
                }

                rdr.Close();
            }

            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
            }

        }

        static void EX05_05(){
            MySqlConnection conn;
            // string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            Console.WriteLine("Give an item: ");
            string category_Name = Console.ReadLine();
            Console.WriteLine("Give a maximum cost: ");
            int max_cost;
            bool isValid = int.TryParse(Console.ReadLine(), out max_cost);
            // the above code is used when we do not know if the user inputted a number
            // out means it is outputting based off the weather max_cost is a int or not and that boolean value is given
            // to isValid
            if (isValid) {
                //Console.WriteLine(" is Valid ");             
                string sql = "SELECT  Category, `standard cost`, `product name`" +   
                " FROM northwind.Products" +
                " WHERE `standard cost` < @max_cost AND Category = '" + category_Name + "'";  
                //   double max_cost = 20;
                try {
                    conn = new MySqlConnection(); // this connects to the local host and user part
                    conn.ConnectionString = myConnectionString; 
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@max_cost", max_cost); // this relates to the double max fee in that
                    // the double max fee is what is replaccing the shipping fee in the query
                    //cmd.Parameters.AddWithValue("@category_Name", category_Name); // WHY does this not work?
                    MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                    bool name_Exists = false;
                    // bool cost_Exists = false;
                    Console.WriteLine("category" + ": " + "standard cost" + ": " + "product name");
                    while (rdr.Read()) { // this reas through and the data like reading through a file
                        name_Exists = true;
                        Console.WriteLine(rdr["category"] + ": " + rdr["standard cost"]  + ": " + rdr["product name"]);
                    }
                    if (!name_Exists){
                        Console.WriteLine("Does not contain that word or cost is too low");
                    }
                rdr.Close();
                }
                catch (MySqlException ex) {
                    Console.WriteLine(ex.Message);
                }
                    // code to execute if max_cost is a valid integer
                } else {
                     Console.WriteLine(" is not a valid number ");
                    // code to execute if max_cost is not a valid integer
                }
               


        }

        static void EX05_06(){
            MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            Console.WriteLine("Give a City: ");
            string city_Name= Console.ReadLine();
            string sql = "SELECT `Shipper ID`, `Ship City`" +
            " FROM northwind.Orders" +
            " WHERE `Ship City` = '"+ city_Name + "'" +
            " GROUP BY `Shipper ID`";  

            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@city_Name", city_Name); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                bool name_Exists = false;
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    name_Exists = true;
                    Console.WriteLine("Shipper ID" + ": " + "Ship City");
                    if (rdr["Shipper ID"] != null){ // why does this not get rid of the NULL value?
                        Console.WriteLine(rdr["Shipper ID"] + ": " + rdr["Ship City"]);                    
                    }
                }
                if (!name_Exists){
                    Console.WriteLine("Does not contain that City");
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }
        
        static void EX05_07(){
            MySqlConnection conn;
            // string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            Console.WriteLine("Give a Job Title: ");
            string job_Title = Console.ReadLine();
               
            string sql = "SELECT `Job Title`"+
            " FROM northwind.Employees" +
            " WHERE `Job Title` LIKE '" + job_Title + "%'";  
            //   double max_cost = 20;
            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                bool name_Exists = false;
               // bool cost_Exists = false;
                Console.WriteLine("Job Title");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    name_Exists = true;
                    Console.WriteLine(rdr["Job Title"]);
                }
                if (!name_Exists){
                    Console.WriteLine("Does not contain that Job Title");
                }
                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }

        // List the ship date for all Orders, and if there is an employee assigned to the order, list the employee’s name.
        static void EX05_08(){
            MySqlConnection conn;
            // string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            string sql = "SELECT o.`Shipped Date`, CONCAT(e.`First name`,' ', e.`Last name`) as name" +
            " FROM northwind.Orders as o join northwind.Employees e on o.`Employee ID` = e.`ID` ";
            //   double max_cost = 20;
            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
               
               // bool cost_Exists = false;
                Console.WriteLine("Shipped Date" + ": " + "name");
                while (rdr.Read()) { // this reads through and the data like reading through a file
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Shipped Date"))){//(rdr["Shipped Date"] != null){
                    // NULL to NULL comparision will always be null which is why the above is what we use to parse out null values
                    Console.WriteLine(rdr["Shipped Date"] + ": " + rdr["name"]);//
                }
                
            }
           rdr.Close();
            } 
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }
        static void EX05_09(){
            MySqlConnection conn;
            // string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            string sql = " SELECT max(`Shipping Fee`) as max, min(`Shipping Fee`) as min, avg(`Shipping Fee`) as average" +
            " FROM northwind.Orders";
            //   double max_cost = 20;
            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
               
                // bool cost_Exists = false;
                Console.WriteLine("max" + ": " + "min" + ": " + "average");
                while (rdr.Read()) { // this reads through and the data like reading through a file
                    // NULL to NULL comparision will always be null which is why the above is what we use to parse out null values
                    Console.WriteLine(rdr["max"] + ": " + rdr["min"] + ": " + rdr["average"]);//
                
            }
           rdr.Close();
            } 
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }
        static void EX05_10(){
            MySqlConnection conn;
            // string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            string sql = " SELECT `Ship City`, max(`Shipping Fee`) as max, min(`Shipping Fee`) as min, avg(`Shipping Fee`) as average" +
            " FROM northwind.Orders" +
            " GROUP BY `Ship City`";
            //   double max_cost = 20;
            try {
                conn = new MySqlConnection(); // this connects to the local host and user part
                conn.ConnectionString = myConnectionString; 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("Ship City" + ": " + "max" + ": " + "min" + ": " + "average");
               // bool cost_Exists = false;
                while (rdr.Read()) { // this reads through and the data like reading through a file
                    // NULL to NULL comparision will always be null which is why the above is what we use to parse out null values
                    Console.WriteLine(rdr["Ship City"] + ": " + rdr["max"] + ": " + rdr["min"] + ": " + rdr["average"]);//
                
            }
           rdr.Close();
         } 
         catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }
/*
SELECT `Ship City`,max(`Shipping Fee`) as max, min(`Shipping Fee`) as min, avg(`Shipping Fee`) as average
 FROM northwind.Orders
 GROUP BY `Ship City`;
*/
        static void Main(string[] args)
        {
          // demo();
           Console.WriteLine("\nEX05_01");
           EX05_01();
           Console.WriteLine("\nEX05_02");
           EX05_02();
           Console.WriteLine("\nEX05_03");
           EX05_03(); // done
           Console.WriteLine("\nEX05_04");
           EX05_04(); // done
           Console.WriteLine("\nEX05_05");
           EX05_05(); // done
           Console.WriteLine("\nEX05_06");
           EX05_06(); // done
           Console.WriteLine("\nEX05_07");
           EX05_07(); // done
           Console.WriteLine("\nEX05_08");
           EX05_08(); // done
           Console.WriteLine("\nEX05_09");
           EX05_09(); // done
           Console.WriteLine("\nEX05_10");
           EX05_10(); // done


        }
    }
}
