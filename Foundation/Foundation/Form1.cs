namespace Foundation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderName = txt_FolderName.Text;
            string professor = txt_Professor.Text;
            int weeks = Int32.Parse(txt_Weeks.Text);

            MessageBox.Show(CreateFolder(folderName, "C:\\git\\GCU", professor, weeks));
        }

        private string CreateFolder(string name, string root, string prof, int weeks)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Please enter a folder name.";

            string path = Path.Combine(root, name);

            if (Directory.Exists(path)) return "Folder already exists.";

            Directory.CreateDirectory(path);

            string mdName = name[0].ToString().ToUpper() + 
                            name[1].ToString().ToUpper() + 
                            name[2].ToString().ToUpper() + "-" + 
                            name[3] + name[4] + name[5];

            for (int i = 0; i < weeks; i++)
            {
                string weekPath = Path.Combine(path, "week" + (i + 1));

                Directory.CreateDirectory(weekPath);

                string docsPath = Path.Combine(weekPath, "docs");

                Directory.CreateDirectory(docsPath);

                string mdPath = Path.Combine(weekPath, "README.md");

                

                File.WriteAllText(mdPath, 
                    "# Cover Sheet\r\n\r\n### Class: " + mdName + 
                    "\r\n### Professor: " + prof + 
                    "\r\n### Author: Phillip Ball\r\n\r\n---");
            }

            return name + " created successfully";
        }
    }
}