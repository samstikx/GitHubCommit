using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.SqliteClient;
using System.Data;
using UnityEngine;

namespace Assets.Scripts
{
    class StudentDatabase : MonoBehaviour
    {
        string filePath;
        int count = 0;

        void Start()
        {
            filePath = "URI=file:" + Application.dataPath + "StudentDatabase.s3db";
            DeleteTable();
            CreateTable();
            InsertIntoStudentTable(new Student("Jordan", "Hooper", 1437265, "Computer Game Tech Bsc"));
            PrintFromStudentTable();
            DeleteTable();
        }

        void InsertIntoStudentTable(Student student)
        {
            using (IDbConnection connection = new SqliteConnection(filePath))
            {
                connection.Open();
                string commandText = "INSERT INTO Students VALUES (" + count.ToString() + ", '" + student.FirstName + "', '" + student.LastName + "', '" + student.StudentID.ToString() + "', '" + student.Course + "')";
                IDbCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
                Debug.Log("Inserted a new student record");
                count++;
            }
        }

        void CreateTable()
        {
            using (IDbConnection connection = new SqliteConnection(filePath))
            {
                connection.Open();
                string commandText = "CREATE TABLE Students (ID INT UNIQUE PRIMARY KEY, FirstName TEXT, LastName TEXT, StudentID INTEGER, Course TEXT)";
                IDbCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
                Debug.Log("Created a new table named Students in StudentDatabase");
            }
        }

        public void PrintFromStudentTable()
        {
            using (IDbConnection connection = new SqliteConnection(filePath))
            {
                connection.Open();
                string commandText = "SELECT * FROM Students";
                IDbCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = Convert.ToString(reader.GetValue(1));
                    string lastName = Convert.ToString(reader.GetValue(2));
                    int studentID = Convert.ToInt32(reader.GetValue(3));
                    string course = Convert.ToString(reader.GetValue(4));
                    Student student = new Student(firstName, lastName, studentID, course);
                    student.PrintInfo();
                }
            }
        }

        void DeleteTable()
        {
            using (IDbConnection connection = new SqliteConnection(filePath))
            {
                connection.Open();
                string commandText = "DROP TABLE IF EXISTS Students ";
                IDbCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
                Debug.Log("Deleted Table named Students in StudentDatabase");
            }
        }
    }
}
