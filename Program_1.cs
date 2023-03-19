// using System;
// using MySqlConnector;

// // dotnet new console -- create new C# project
// // dotnet add package MySqlConnector -- add the MySQL Connector package
// // dotnet build -- build the application

// namespace Downloads
// {
//     class Program_1
//     {
       
//             MySqlConnection conn;
//             string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
//             string sql = "SELECT C.`Company`, E.`Last Name` " +
//                 "FROM Customers C, Employees E, Orders O " +
//                 "WHERE E.ID=O.`Employee ID` AND C.ID=O.`Customer ID` AND " +
//                 "O.`Shipping Fee` < @shipping_fee " +
//                 "ORDER BY O.`Shipping Fee`";
//             double maxfee = 20;

//             try {
//                 conn = new MySqlConnection(); // this connects to the local host and user part
//                 conn.ConnectionString = myConnectionString; 
//                 conn.Open();

//                 MySqlCommand cmd = new MySqlCommand(sql, conn);
//                 cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
//                 // the double max fee is what is replaccing the shipping fee in the query
//                 MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code

//                 while (rdr.Read()) { // this reas through and the data like reading through a file
//                     Console.WriteLine(rdr["Company"] + ": " + rdr["Last Name"]);
//                 }

//                 rdr.Close();
//             }
//             catch (MySqlException ex) {
//                 Console.WriteLine(ex.Message);
//             }
        
//     }
// }
