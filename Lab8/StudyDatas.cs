using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class StudyDatas : Form, IOneOfMany<Form>
    {
        public StudyDatas(StudentData student)
        {
            InitializeComponent();
            this.student = student;
            error.BlinkRate = 2;
        }
        private ErrorProvider error = new ErrorProvider();
        private StudentData student;
        public void SetUID(uint uid)
        {
            labelID.Text = uid.ToString();
        }
        public event Action<Form> ShowNext;
        public event Action<Form> ShowPrevious;
        private void buttonNextClick(object sender, EventArgs e)
        {

        }
        private void buttonPrevClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                ShowPrevious(this);
            }
        }

        private void StudyDatas_Load(object sender, EventArgs e)
        {
            string[] tracks = StudentData.AllTracks.Split('\n');
            foreach (var subj in tracks)
                comboBox1.Items.Add(subj);
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if(comboBox1.SelectedIndex==-1)
            {
                e.Cancel = true;
                error.SetError(comboBox1, "Направление должно быть выбрано!");
            }
            else
            {
                e.Cancel = false;
                error.SetError(comboBox1, "");
            }        
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (int.Parse(maskedTextBox1.Text) < 5 && int.Parse(maskedTextBox1.Text) > 0)
                {
                    e.Cancel = false;
                    error.SetError(maskedTextBox1, "");
                }
                else
                    throw new FormatException();
            }
            catch
            {
                e.Cancel = true;
                error.SetError(maskedTextBox1, "Должно принимать значения от 1 до 4");
            }
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (int.Parse(maskedTextBox2.Text) < 5 && int.Parse(maskedTextBox2.Text) > 0)
                {
                    e.Cancel = false;
                    error.SetError(maskedTextBox2, "");
                }
                else
                    throw new FormatException();
            }
            catch
            {
                e.Cancel = true;
                error.SetError(maskedTextBox2, "Должно принимать значения от 1 до 4");
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                student.Track = comboBox1.SelectedItem.ToString();
                student.Course = int.Parse(maskedTextBox1.Text);
                student.Group = int.Parse(maskedTextBox2.Text);
                this.Close();
            }
        }
    }
}
