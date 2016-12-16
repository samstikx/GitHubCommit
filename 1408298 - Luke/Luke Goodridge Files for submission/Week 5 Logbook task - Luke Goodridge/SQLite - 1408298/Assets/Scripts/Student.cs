using UnityEngine;

public class Student
{
    public string FirstName
    {
        get { return firstName; }
    }
    public string LastName
    {
        get { return lastName; }
    }
    public int StudentID
    {
        get { return studentID; }
    }
    public string Course
    {
        get { return course; }
    }

    private string firstName;
    private string lastName;
    private int studentID;
    private string course;

    /// <summary>
    /// Initialises an instance of a student class containing information.
    /// </summary>
    public Student(string firstName, string lastName, int studentID, string course)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.studentID = studentID;
        this.course = course;
    }

    /// <summary>
    /// Prints the student's information to the console window.
    /// </summary>
    public void PrintInfo()
    {
        Debug.Log(firstName + "\t" + lastName + "\t" + studentID.ToString() + "\t" + course);
    }
}
