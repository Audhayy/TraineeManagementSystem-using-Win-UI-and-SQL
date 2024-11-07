using System.Collections.Generic;
using ZstdSharp.Unsafe;
using MySql.Data.MySqlClient;
using System;


namespace Win_UI_Sample.Repositories
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly string _connectionstring = "Server = localhost; Database=traineemanagementsystem; Uid= root;";
        private static TraineeRepository _instance;

        public static ITraineeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TraineeRepository();
                }
                return _instance;
            }
        }

        public void AddTrainee(Dictionary<string, object> traineeData)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionstring))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO trainee(Name, MobileNumber, Address, DateOfBirth, Qualification, Department, Email, StartDate, EndDate, IsDeleted)" + "VALUES(@Name, @MobileNumber, @Address, @DateOfBirth, @Qualification, @Department, @Email, @StartDate, @EndDate, @IsDeleted)", con);
                    cmd.Parameters.AddWithValue("@Name", traineeData["Name"]);
                    cmd.Parameters.AddWithValue("@MobileNumber", traineeData["MobileNumber"]);
                    cmd.Parameters.AddWithValue("@Address", traineeData["Address"]);
                    cmd.Parameters.AddWithValue("@DateOfBirth", traineeData["DateOfBirth"]);
                    cmd.Parameters.AddWithValue("@Qualification", traineeData["Qualification"]);
                    cmd.Parameters.AddWithValue("@Department", traineeData["Department"]);
                    cmd.Parameters.AddWithValue("@Email", traineeData["Email"]);
                    cmd.Parameters.AddWithValue("@StartDate", traineeData["StartDate"]);
                    cmd.Parameters.AddWithValue("@EndDate", traineeData["EndDate"]);
                    cmd.Parameters.AddWithValue("@IsDeleted", traineeData.ContainsKey("IsDeleted") ? traineeData["IsDeleted"] : false);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Trainee has been added successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding the trainee"+ex.Message);
                }
            }
          //  TraineesList.Add(traineeData);
        }
        public List<Dictionary<string, object>> GetAllTrainees()
        {
            List<Dictionary<string, object>> trainees = new List<Dictionary<string, object>>();

            using (MySqlConnection con = new MySqlConnection(_connectionstring))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT TraineeID, Name, MobileNumber, Address, DateOfBirth, Qualification, Department, Email, StartDate, EndDate, IsDeleted FROM trainee WHERE IsDeleted = 0", con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> trainee = new Dictionary<string, object>
                            {
                                { "TraineeID", reader["TraineeID"] },
                                { "Name", reader["Name"] },
                                { "MobileNumber", reader["MobileNumber"] },
                                { "Address", reader["Address"] },
                                { "DateOfBirth", reader["DateOfBirth"] },
                                { "Qualification", reader["Qualification"] },
                                { "Department", reader["Department"] },
                                { "Email", reader["Email"] },
                                { "StartDate", reader["StartDate"] },
                                { "EndDate", reader["EndDate"] },
                                { "IsDeleted", reader["IsDeleted"] }
                            };

                            trainees.Add(trainee);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching trainees: " + ex.Message);
                }
            }

            return trainees;
        }
    }
}