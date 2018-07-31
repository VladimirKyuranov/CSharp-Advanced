using System;
using System.Collections.Generic;
using System.Linq;

class Hospital
{
    static void Main(string[] args)
    {
        string input;
        List<Patient> patients = new List<Patient>();
        Dictionary<string, int> departments = new Dictionary<string, int>();

        while ((input = Console.ReadLine()) != "Output")
        {
            string[] patientInfo = input
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string department = patientInfo[0];
            string doctor = $"{patientInfo[1]} {patientInfo[2]}";
            string patientName = patientInfo[3];

            if (departments.ContainsKey(department) && departments[department] == 60)
            {
                continue;
            }

            if (departments.ContainsKey(department) == false)
            {
                departments.Add(department, 0);
            }

            Patient currentPatient = new Patient
            {
                Name = patientName,
                Doctor = doctor,
                Department = department,
                Room = departments[department] / 3 + 1
            };

            departments[department]++;
            patients.Add(currentPatient);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string[] filterArgs = input
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var getFilteredPatients = GetFilteredPatients(filterArgs);
            List<Patient> filteredPatients = getFilteredPatients(patients);

            filteredPatients.ForEach(p => Console.WriteLine(p.Name));
        }
    }

    static Func<List<Patient>, List<Patient>> GetFilteredPatients(string[] filterArgs)
    {
        if (filterArgs.Length == 1)
        {
            string department = filterArgs[0];
            return l => l.Where(p => p.Department == department).ToList();
        }
        else
        {
            try
            {
                string department = filterArgs[0];
                int room = int.Parse(filterArgs[1]);

                return l => l.Where(p => p.Department == department && p.Room == room).OrderBy(p => p.Name).ToList();
            }
            catch (Exception)
            {
                string doctor = $"{filterArgs[0]} {filterArgs[1]}";

                return l => l.Where(p => p.Doctor == doctor).OrderBy(p => p.Name).ToList();
            }
        }
    }
}

class Patient
{
    public string Name { get; set; }
    public string Doctor { get; set; }
    public string Department { get; set; }
    public int Room { get; set; }
}