using System;

namespace TFDAGUI
{
    public partial class Form1 : Form
    {
        string outPath = @"C:\demos\peopleOut.txt";

        List<string> output = new List<string>();
        List<Person> people = new List<Person>();

        public Form1()
        {
            InitializeComponent();
            output = File.ReadAllLines(outPath).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0) return;

            people.Add(new Person(textBox1.Text, textBox2.Text, textBox3.Text));

            UpdateListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count <= 0)
            {
                MessageBox.Show("There is nothing to save...");
                return;
            }

            output.Clear();

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                output.Add(people[i].Print());
            }

            File.WriteAllLines(outPath, output);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (string line in output)
            {
                listBox1.Items.Add(line);
            }
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (Person person in people)
            {
                listBox1.Items.Add(person.Print());
            }
        }
    }
}