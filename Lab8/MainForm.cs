using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab8
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private static StudentData student = new StudentData();

        static void OnShutdown(object sender, EventArgs args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StudentData));
            var stream = new StreamWriter("test.xml");
            serializer.Serialize(stream, student);
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new MultiFormContext(new PersonalDatas(student), new ContactDatas(student), new StudyDatas(student));
            context.ThreadExit += OnShutdown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter= "xml files(*.xml)|*.xml";

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            XmlSerializer serializer = new XmlSerializer(typeof(StudentData));
            var sw = new FileStream(ofd.FileName, FileMode.Open);
            StudentData student = (StudentData) serializer.Deserialize(sw);
            textBox1.Text = student.Name;
            textBox2.Text = student.Gender.ToString();
            textBox3.Text = student.BirthDay.Date.ToString();
            textBox4.Text = student.Passport;
            textBox5.Text = student.City;
            textBox6.Text = student.Address;
            textBox7.Text = student.Phone;
            textBox8.Text = student.Email;
            textBox9.Text = student.Track;
            textBox10.Text = student.Course.ToString();
            textBox11.Text = student.Group.ToString();
        }
    }
}
