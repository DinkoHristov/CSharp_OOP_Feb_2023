using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (this.students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);

            this.students.AddModel(student);

            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(EconomicalSubject) && 
                subjectType != nameof(HumanitySubject) &&
                subjectType != nameof(TechnicalSubject))
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if (subjects.Models.Any(s => s.Name == subjectName))
            {
                return $"{subjectName} is already added in the repository.";
            }

            ISubject subject = null;

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }

            this.subjects.AddModel(subject);

            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (this.universities.Models.Any(u => u.Name == universityName))
            {
                return $"{universityName} is already added in the repository.";
            }

            List<int> ids = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                ids.Add(subjects.FindByName(subject).Id);
            }

            IUniversity university =
                new University(this.universities.Models.Count + 1, universityName, category, capacity, ids);

            this.universities.AddModel(university);

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            if (!students.Models
                .Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is not registered in the application!";
            }

            if (!universities.Models.Any(u => u.Name == universityName))
            {
                return $"{universityName} is not registered in the application!";
            }

            IStudent student = students.Models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            IUniversity university = universities.Models.FirstOrDefault(u => u.Name == universityName);

            if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return $"{student.FirstName} {student.LastName} has already joined {university.Name}.";
            }

            student.JoinUniversity(university);

            return $"{student.FirstName} {student.LastName} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(s => s.Id == studentId))
            {
                return "Invalid student ID!";
            }

            if (!subjects.Models.Any(s => s.Id == subjectId))
            {
                return "Invalid subject ID!";
            }

            IStudent student = students.Models.FirstOrDefault(s => s.Id == studentId);
            ISubject subject = subjects.Models.FirstOrDefault(s => s.Id == subjectId);

            if (student.CoveredExams.Any(e => e == subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);

            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.Models.FirstOrDefault(u => u.Id == universityId);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"*** {university.Name} ***");
            result.AppendLine($"Profile: {university.Category}");
            result.AppendLine($"Students admitted: {this.students.Models.Where(s => s.University == university).Count()}");
            result.AppendLine($"University vacancy: {university.Capacity - this.students.Models.Where(s => s.University == university).Count()}");

            return result.ToString().TrimEnd();
        }
    }
}
