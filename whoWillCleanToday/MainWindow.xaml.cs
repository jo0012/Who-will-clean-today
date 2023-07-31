using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace whoWillCleanToday
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void CreateTxtFile(string path)
        {
            File.WriteAllText(path, "");
            return;
        }

        private void CheckIfTxtFileExists(string path)
        {
            // Check if there is a file for student data. If not, create a new one.
            if (!File.Exists(path))
            {
                if (path == @"studentList.txt")
                {
                    MessageBox.Show("There is no student list. Click OK to create a new student list.");
                    CreateTxtFile(path);
                }
                else if (path == @"exceptionList.txt")
                {
                    MessageBox.Show("There is no exception list. Click OK to create a new exception list.");
                    CreateTxtFile(path);
                }
                else
                {
                    MessageBox.Show("[ERROR] An attempt to create an undefined file was detected. The program will be terminated to protect the computer from unexpected errors.\nClick OK to terminate this program.");
                    CloseProgram();
                }
            }
            else
            {
                if (path == @"studentList.txt")
                {
                    AddTxtToListBox(path, ListBox_studentList);
                }
                else if (path == @"exceptionList.txt")
                {
                    AddTxtToListBox(path, ListBox_exceptionList);
                }
                else 
                {
                    return;
                }
            }
        }

        private void UpdateTheNumberOfStudents()
        {
            Label_studentNumber.Content = "전체 학생 수 : " + ListBox_studentList.Items.Count.ToString();
            Label_exceptionNumber.Content = "청소 면제자 수 : " + ListBox_exceptionList.Items.Count.ToString();
        }

        private void CloseProgram()
        {
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void AddTxtToListBox(string path, ListBox listBox)
        {
            StreamReader file = new StreamReader(path, Encoding.Default);
            string line = "";
            listBox.Items.Clear();

            while (line != null)
            { 
                line = file.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    listBox.Items.Add(line);
                }
            }
            file.Close();
        }

        private void AddListBoxToTxt(ListBox listBox, string fileName)
        {
            StreamWriter streamLine;
            streamLine = new StreamWriter(fileName);
            int numberOfStudents = listBox.Items.Count;

            for (int i = 0; i < numberOfStudents; i++)
            {
                listBox.Items[i] = listBox.Items[i];
                if (i == (numberOfStudents - 1))
                {
                    streamLine.Write(listBox.Items[i]);
                }
                else 
                {
                    streamLine.WriteLine(listBox.Items[i]);
                }           
            }
            streamLine.Close();
        }

        private void AddStudent(string newName)
        {
            ListBox_studentList.Items.Add(newName);
            AddListBoxToTxt(ListBox_studentList, @"studentList.txt");
            UpdateTheNumberOfStudents();
        }

        private void AddException(string newName)
        {
            ListBox_exceptionList.Items.Add(newName);
            AddListBoxToTxt(ListBox_exceptionList, @"exceptionList.txt");
            UpdateTheNumberOfStudents();
        }

        private void RemoveStudent(string name)
        {
            ListBox_studentList.Items.Remove(name);
            for (int i = 0; i < ListBox_exceptionList.Items.Count; i++)
            {
                if (ListBox_exceptionList.Items[i].ToString() == name)
                {
                    ListBox_exceptionList.Items.Remove(name);
                }
            }
            AddListBoxToTxt(ListBox_studentList, @"studentList.txt");
            AddListBoxToTxt(ListBox_exceptionList, @"exceptionList.txt");
            UpdateTheNumberOfStudents();
        }

        private void RemoveException(string name)
        {
            ListBox_exceptionList.Items.Remove(name);
            AddListBoxToTxt(ListBox_exceptionList, @"exceptionList.txt");
            UpdateTheNumberOfStudents();
        }        

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            CloseProgram();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            CheckIfTxtFileExists(@"studentList.txt");
            CheckIfTxtFileExists(@"exceptionList.txt");
            UpdateTheNumberOfStudents();
        }

        private void Button_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            AddStudent childWindow = new AddStudent(false);
            childWindow.ShowDialog();
            if (childWindow.buttonOK_pressed)
            {
                str = ((childWindow).studentName);
                AddStudent(str);
            }
        }

        private void Button_RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_studentList.SelectedItem == null)
            {
                MessageBox.Show("삭제할 학생을 지정해주십시오.");
            }
            else
            {
                if (MessageBox.Show(ListBox_studentList.SelectedItem.ToString() + " 학생의 정보는 돌아오지 않습니다.\n정말로 삭제하시겠습니까?", "경고", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    RemoveStudent(ListBox_studentList.SelectedItem.ToString());
                }
            }
        }

        private void Button_AddException_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            AddStudent childWindow = new AddStudent(true);
            childWindow.ShowDialog();
            if (childWindow.buttonOK_pressed)
            {
                str = ((childWindow).studentName);
                AddException(str);
                return;
            }
            else
            {
                return;
            }
        }

        private void Button_RemoveException_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_exceptionList.SelectedItem == null)
            {
                MessageBox.Show("면제 대상에서 제외할 학생을 지정해주십시오.");
            }
            else
            {
                RemoveException(ListBox_exceptionList.SelectedItem.ToString());
            }
        }

        private void Button_Launch_Click(object sender, RoutedEventArgs e)
        {
            ListBox_todaysCleaners.Items.Clear();
            Random rand = new Random();
            bool overlappedStudentDetected = false;
            bool exceptedStudentDetected = false;
            int todaysCleaner = 0;
            int cnt = 0;

            if ((ListBox_studentList.Items.Count - ListBox_exceptionList.Items.Count) < 4)
            {
                MessageBox.Show("청소할 학생의 수가 부족합니다. 청소 인원은 최소 4명이 필요합니다.");
            }
            else
            {
                while (cnt < 4)
                {
                    overlappedStudentDetected = false;
                    exceptedStudentDetected = false;
                    todaysCleaner = rand.Next(0, ListBox_studentList.Items.Count);
                    for (int i = 0; i < ListBox_todaysCleaners.Items.Count; i++)
                    {
                        if (ListBox_todaysCleaners.Items[i].ToString() == ListBox_studentList.Items[todaysCleaner].ToString())
                        {
                            overlappedStudentDetected = true;
                        }
                    }

                    for (int i = 0; i < ListBox_exceptionList.Items.Count; i++)
                    {
                        if (ListBox_exceptionList.Items[i].ToString() == ListBox_studentList.Items[todaysCleaner].ToString())
                        {
                            exceptedStudentDetected = true;
                        }
                    }

                    if (overlappedStudentDetected || exceptedStudentDetected)
                    {
                        continue;
                    }
                    else
                    {
                        ListBox_todaysCleaners.Items.Add(ListBox_studentList.Items[todaysCleaner].ToString());
                        cnt++;
                    }
                }

                AddListBoxToTxt(ListBox_todaysCleaners, @"exceptionList.txt"); 
                AddTxtToListBox(@"exceptionList.txt", ListBox_exceptionList);
            }           
        }
    }
}
