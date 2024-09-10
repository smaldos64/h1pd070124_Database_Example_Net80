using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Example_Net80.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace Database_Example_Net80.ViewModels
{
    public class StudentCourseViewModel : ViewModelBase
    {
        private Student _student_Object;
        private string _studentCourseString;
        //private string _schoolName = "TechCollege";

        public Student Student_Object
        {
            get
            {
                return (this._student_Object);
            }
            set
            {
                this._student_Object = value;
                OnPropertyChanged("Student_Object");
            }
        }

        public string StudentCourseString
        {
            get
            {
                return (this._studentCourseString);
            }
            set
            {
                this._studentCourseString = value;
                //OnPropertyChanged("StudentCourseString");
                // Mere optimalt rent kodemæssigt at have kodelinjen herover
                // i funktionen SetCoursesString, da OnPropertyChanged så kun
                // vil blive kaldt én gang i forbindelese med oprettelse/
                // opdatering af en student.
            }
        }
        //public string SchoolName
        //{
        //    get
        //    {
        //        return (this._schoolName);
        //    }
        //    set
        //    {
        //        this._schoolName = value;
        //        OnPropertyChanged("SchoolName");
        //    }
        //}
        //public StudentCourseViewModel(Student Student_Object, 
        //                              DatabaseContext DBContext) : base(DBContext)
        public StudentCourseViewModel(Student Student_Object)
        {
            this.Student_Object = Student_Object;
        }
                
        public void SetCoursesString()
        {
            if (this.Student_Object.Courses.Count > 0)
            {
                this.StudentCourseString = "";

                foreach (Course Course_Object in this.Student_Object.Courses)
                {
                    this.StudentCourseString += Course_Object.CourseName + "\r\n";
                }
            }
            else
            {
                this.StudentCourseString = "----------";
            }
            OnPropertyChanged("StudentCourseString");
        }

        public void NotifyAboutStudentUpdateAfterMapsterCloneData()
        {
            OnPropertyChanged("Student_Object");
        }
    }
}
