using System.Collections.Generic;

public class Group
{
    public string Name { get; set; }
    public List<Student> Students { get; } = new List<Student>();
    public List<string> Subjects { get; } = new List<string>();
}