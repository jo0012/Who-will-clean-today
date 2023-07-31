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
using System.Windows.Shapes;

namespace whoWillCleanToday
{
    /// <summary>
    /// AddStudent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddStudent : Window
    {
        public string studentName = "";
        public bool buttonOK_pressed = false;
        public bool addExceptionFlag = false;

        public AddStudent(bool addExceptionFlag)
        {
            InitializeComponent();
            this.addExceptionFlag = addExceptionFlag;
        }

        private bool OverlappedNameDetected (string newName, string fileName)
        {
            StreamReader file = new StreamReader(fileName, Encoding.Default);
            string line = "";

            while (line != null)
            {
                line = file.ReadLine();
                if (line == newName)
                {
                    file.Close();
                    return true;
                }
            }
            file.Close();

            return false;
        }

        private bool IsThereAStudentWhoseNameIs (string newName)
        {
            StreamReader file = new StreamReader(@"studentList.txt", Encoding.Default);
            string line = "";
            while (line != null)
            {
                line = file.ReadLine();
                if (line == newName)
                {
                    file.Close();
                    return true;
                }
            }
            file.Close();

            return false;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (!addExceptionFlag)
            {
                if (textBox_newStudentsName.Text == "")
                {
                    MessageBox.Show("새로 추가하실 학생의 이름을 입력해주십시오.");
                }
                else if (OverlappedNameDetected(textBox_newStudentsName.Text, @"studentList.txt"))
                {
                    MessageBox.Show("동일한 이름의 학생은 입력하실 수 없습니다. 동명이인의 학생이 존재하는 경우 숫자 등으로 분류해주시기 바랍니다. \n(예. 홍길동1, 홍길동2)");
                }
                else
                {
                    studentName = textBox_newStudentsName.Text;
                    buttonOK_pressed = true;
                    this.Close();
                }
            }
            else
            {
                if (textBox_newStudentsName.Text == "")
                {
                    MessageBox.Show("청소를 면제시키실 학생의 이름을 입력해주십시오.");
                }
                else if (OverlappedNameDetected(textBox_newStudentsName.Text, @"exceptionList.txt"))
                {
                    MessageBox.Show("동일한 이름의 학생은 입력하실 수 없습니다. 동명이인의 학생이 존재하는 경우 숫자 등으로 분류해주시기 바랍니다. \n(예. 홍길동1, 홍길동2)");
                }
                else
                {
                    if (IsThereAStudentWhoseNameIs(textBox_newStudentsName.Text))
                    {
                        studentName = textBox_newStudentsName.Text;
                        buttonOK_pressed = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("존재하지 않는 학생명입니다.");
                    }
                }
            }
            return;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            studentName = "";
            buttonOK_pressed = false;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            buttonOK_pressed = false;
            this.Close();
        }
    }
}
