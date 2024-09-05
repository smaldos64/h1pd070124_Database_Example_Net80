using Database_Example_Net80.ViewModels;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Database_Example_Net80.Models;
using Database_Example_Net80.Windows;
using Database_Example_Net80.Tools;
using Database_Example_Net80.ExtensionMethods;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Configuration;

namespace Database_Example_Net80
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //public static class ServiceCollectionExtensions
    //{
    //    public static void ConfigureServices(this IServiceCollection services,
    //                                         IConfiguration config)
    //    {
    //        var connectionString = config["ConnectionStrings:cityInfoDBConnectionString"];

    //        services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connectionString));
    //    }
    //}
    public partial class MainWindow : Window
    {
        private DatabaseContext db = new DatabaseContext();
        public static ObservableCollection<StudentCourseViewModel> StudentList = new ObservableCollection<StudentCourseViewModel>();

        
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.DataContext = StudentList;

            //ServiceCollection services = new ServiceCollection();
            //services.ConfigureServices();


            //SetupDatabaseConnection();

            BindStudentList();
        }

        //private void SetupDatabaseConnection()
        //{
        //    string DBConnectionString;

        //    DBConnectionString = this.Confi _configuration.GetConnectionString("cityInfoDBConnectionString");
        //}

        private void BindStudentList()
        {
            DatabaseContext db = new DatabaseContext();

            List<Student> StudentListFromDB = new List<Student>();
            StudentListFromDB = db.Students.ToList();

            dataGrid.Items.Clear();

            foreach (Student Student_Object in StudentListFromDB)
            {
                StudentCourseViewModel StudentCourseMethodWindow_Object = new StudentCourseViewModel(Student_Object);

                StudentCourseMethodWindow_Object.SetCourses();
                StudentList.Add(StudentCourseMethodWindow_Object);

                dataGrid.Items.Add(StudentCourseMethodWindow_Object);
            }

        }

        private void btnEraseStudent_Click(object sender, RoutedEventArgs e)
        {
            Button ThisButon = sender as Button;
            int StudentID = Convert.ToInt32(ThisButon.Content);

            StudentCourseViewModel StudentViewModelObject = StudentList.Single(s => s.Student_Object.StudentID == StudentID);

            MessageBoxResult Result = MessageBox.Show("Ønsker du virkelig at slette eleven " + StudentViewModelObject.Student_Object.StudentName, "Slet Elev ?", MessageBoxButton.OKCancel);

            if (MessageBoxResult.OK == Result)
            {
                Student StudentObjectFromDB = db.Students.Find(StudentID);
                db.Students.Remove(StudentObjectFromDB);
                db.SaveChanges();
                bool Test = StudentList.Remove(StudentViewModelObject);
                dataGrid.Items.Remove(StudentViewModelObject);
            }
        }

        private void btnModifyStudent_Click(object sender, RoutedEventArgs e)
        {
            int IndexInlist;
            int Counter;

            Button ThisButon = sender as Button;
            int StudentID = Convert.ToInt32(ThisButon.Content);

            // Skift til ModifyStudentWindow vindue/view
            ModifyStudentWindow dlg = new ModifyStudentWindow(StudentID);
            dlg.ShowDialog();

            IndexInlist = StudentList.FindIndex(s => s.Student_Object.StudentID == StudentID);
            //IndexInlist = 0;
            if (-1 != IndexInlist)
            {
                //StudentList[IndexInlist].Student_Object.StudentName = dlg.Student_Object.StudentName;
                //StudentList[IndexInlist].Student_Object.StudentLastName = dlg.Student_Object.StudentLastName;
                //StudentList[IndexInlist].Student_Object.TeamID = dlg.Student_Object.TeamID;
                //StudentList[IndexInlist].Student_Object.Team = dlg.Student_Object.Team;

                //StudentList[IndexInlist].Student_Object.Courses.Clear();
                //for (Counter = 0; Counter < dlg.Student_Object.Courses.Count; Counter++)
                //{
                //    Course CourseObject = new Course();
                //    CourseObject.CourseID = dlg.Student_Object.Courses[Counter].CourseID;
                //    CourseObject.CourseName = dlg.Student_Object.Courses[Counter].CourseName;
                //    StudentList[IndexInlist].Student_Object.Courses.Add(CourseObject);
                //}
                StudentList[IndexInlist].Student_Object = dlg.Student_Object.CopyStudentObjectFields();
                StudentList[IndexInlist].SetCourses();
            }
        }

        private void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow dlg = new AddStudentWindow();
            dlg.ShowDialog();

            StudentList.Add(new StudentCourseViewModel(dlg.Student_Object));
            StudentList.Last().SetCourses();
            dataGrid.Items.Add(StudentList.Last());
        }

        
    }
}