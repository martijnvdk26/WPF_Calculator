using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPF_Calculator
{
	internal class Repository
	{
		string connectionString = "SERVER=localhost;DATABASE=wpf_calc;UID=root;pwd=Test@1234!;";

		public void insertInDb(int type, string from, string to, double val1, double val2)
		{
			MySqlConnection con = new MySqlConnection(connectionString);
			string sql = "INSERT INTO Geschiedenis (SoortBerekening, van, naar, valuta_1, valuta_2) VALUES (@type, @from, @to, @val1, @val2)";
			try
			{
				con.Open();

				MySqlCommand cmd = new MySqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@type", type);
				cmd.Parameters.AddWithValue("@from", from);
				cmd.Parameters.AddWithValue("@to", to);
				cmd.Parameters.AddWithValue("@val1", val1.ToString());
				cmd.Parameters.AddWithValue("@val2", val2.ToString());
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			con.Close();
		}

		public void insertInDb(int type, string from, string to, string to2, double val1, double val2, double val3)
		{
			MySqlConnection con = new MySqlConnection(connectionString);
			string sql = "INSERT INTO Geschiedenis (SoortBerekening, van, naar, naar_2, valuta_1, valuta_2, valuta_3) VALUES (@type, @from, @to, @to2, @val1, @val2, @val3)";
			try
			{
				con.Open();

				MySqlCommand cmd = new MySqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@type", type);
				cmd.Parameters.AddWithValue("@from", from);
				cmd.Parameters.AddWithValue("@to", to);
				cmd.Parameters.AddWithValue("@to2", to2);
				cmd.Parameters.AddWithValue("@val1", val1.ToString());
				cmd.Parameters.AddWithValue("@val2", val2.ToString());
				cmd.Parameters.AddWithValue("@val3", val3.ToString());
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			con.Close();
		}

		public void insertInDb(int type, string from, string to, double val1, string val2)
		{
			MySqlConnection con = new MySqlConnection(connectionString);
			string sql = "INSERT INTO Geschiedenis (SoortBerekening, van, naar, valuta_1, valuta_2) VALUES (@type, @from, @to, @val1, @val2)";
			try
			{
				con.Open();

				MySqlCommand cmd = new MySqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@type", type);
				cmd.Parameters.AddWithValue("@from", from);
				cmd.Parameters.AddWithValue("@to", to);
				cmd.Parameters.AddWithValue("@val1", val1.ToString());
				cmd.Parameters.AddWithValue("@val2", val2);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			con.Close();
		}

		public DataTable getHistory()
		{
			MySqlConnection con = new MySqlConnection(connectionString);
			string sql = "SELECT * FROM Geschiedenis ORDER BY ID DESC"; 
			try
			{
				con.Open();

				MySqlCommand cmd = new MySqlCommand(sql, con);
				DataTable dt = new DataTable();
				dt.Load(cmd.ExecuteReader());
				con.Close();
				return dt;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				con.Close();
				return new DataTable();
			}
		}

		public DataTable clearHistory()
		{
			MySqlConnection con = new MySqlConnection(connectionString);
			string sql = "truncate table geschiedenis;SELECT * FROM Geschiedenis ORDER BY ID DESC";
			try
			{
				con.Open();

				MySqlCommand cmd = new MySqlCommand(sql, con);
				DataTable dt = new DataTable();
				dt.Load(cmd.ExecuteReader());
				con.Close();
				return dt;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				con.Close();
				return new DataTable();
			}
		}
	}
}
